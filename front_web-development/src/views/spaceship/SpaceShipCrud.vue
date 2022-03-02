<template>
  <div>
    <DialogMessage
      :dialogOptions="dialogOptions"
      @dialog_false="callback_dialog($event)"
    />
    <DialogDelete
      :dialogDelete="dialogDelete"
      @delete_confirm="deleteItemConfirm"
      @false_dialog="closeDelete"
    />
    <v-dialog v-model="dialogLoaging" max-width="500px">
      <v-card>
        <v-card-title class="body-style d-flex justify-center"
          >Aguarde!</v-card-title
        >
        <v-card-actions
          :loading="deleteLoading"
          class="d-flex justify-content-around"
        >
        </v-card-actions>
        <center class="border-0">
          <v-btn
            :style="{ backgroundColor: 'rgb(30, 30, 30)' }"
            class="border-0 body-style d-flex justify-center"
            :loading="deleteLoading"
            >.</v-btn
          >
        </center>
      </v-card>
    </v-dialog>

    <div class="d-flex justify-center titulo">{{ title }}</div>
    <div>
      <v-text-field
        label="Nome"
        v-model="shipsData.name"
        color="white"
        :disabled="inputDisable"
      ></v-text-field>
      <div v-if="v$.shipsData.name.$error">
        <v-alert border="bottom" color="pink darken-1" dark>
          O campo
          <strong>"Nome"</strong>
          não pode ficar vazio
        </v-alert>
      </div>

      <label>Cor</label>
      <v-text-field
        v-model="shipsData.color"
        :v-mask="mask"
        hide-details
        class="ma-0 pa-0"
        solo
      >
        <template v-slot:append>
          <v-menu
            v-model="menu"
            top
            nudge-bottom="105"
            nudge-left="16"
            :close-on-content-click="false"
          >
            <template v-slot:activator="{ on }">
              <div :style="swatchStyle" v-on="on" />
            </template>
            <v-card>
              <v-card-text class="pa-0">
                <v-color-picker v-model="shipsData.color" flat />
              </v-card-text>
            </v-card>
          </v-menu>
        </template>
      </v-text-field>
      <div v-if="v$.shipsData.color.$error">
        <v-alert border="bottom" color="pink darken-1" dark>
          O campo
          <strong>"Cor"</strong>
          não pode ficar vazio
        </v-alert>
      </div>

      <v-row align="center">
        <v-col cols="12">
          <v-select
            :items="itemsYear"
            v-model="shipsData.year"
            label="Ano"
          ></v-select>
        </v-col>
      </v-row>
      <div v-if="v$.shipsData.year.$error">
        <v-alert border="bottom" color="pink darken-1" dark>
          O campo
          <strong>"Ano"</strong>
          não pode ficar vazio
        </v-alert>
      </div>

      <v-row align="center">
        <v-col cols="11">
          <v-select
            label="Tipo"
            v-model="shipsData.spaceShipTypeId"
            :items="getSpaceShipType"
            item-text="name"
            item-value="id"
            sm="6"
          ></v-select>
        </v-col>
        <v-col cols="1" align="right">
          <v-dialog v-model="dialog" width="500">
            <template v-slot:activator="{ on, attrs }">
              <v-btn class="btn-gold" dark fab small v-bind="attrs" v-on="on">
                <v-icon dense>mdi-plus</v-icon>
              </v-btn>
            </template>
            <v-card>
              <v-container>
                <SpaceShipTypeCrud
                  @cadastro_de_tipo_de_nave="fechar_dialog($event)"
                />
              </v-container>
            </v-card>
          </v-dialog>
        </v-col>
      </v-row>
      <div v-if="v$.shipsData.spaceShipTypeId.$error">
        <v-alert border="bottom" color="pink darken-1" dark>
          O campo
          <strong>"Tipo"</strong>
          não pode ficar vazio
        </v-alert>
      </div>

      <v-row align="center">
      <v-col cols="11">
        <v-select
          label="Peça"
          v-model="PartsPerShip.partId"
          :items="getPart"
          item-text="name"
          item-value="id"
          sm="6"
        ></v-select>
      </v-col>
      <v-col cols="1" align="right">
        <v-dialog v-model="dialogPart" width="500">
          <template v-slot:activator="{ on, attrs }">
            <v-btn class="btn-gold" dark fab small v-bind="attrs" v-on="on">
              <v-icon dense>mdi-plus</v-icon>
            </v-btn>
          </template>
          <v-card>
            <v-container>
              <PartsCrud @cadastro_de_peca="close_dialogPart($event)" />
            </v-container>
          </v-card>
        </v-dialog>
      </v-col>
    </v-row>
    <div v-if="v$.PartsPerShip.partId.$error">
      <v-alert border="bottom" color="pink darken-1" dark>
        O campo
        <strong>"Peça"</strong>
        não pode ficar vazio
      </v-alert>
    </div>

     

      <v-textarea
        label="Descrição"
        v-model="shipsData.description"
        color="white"
        :disabled="inputDisable"
      ></v-textarea>
      <div v-if="v$.shipsData.description.$error">
        <v-alert border="bottom" color="pink darken-1" dark>
          O campo
          <strong>"Descrição"</strong>
          não pode ficar vazio
        </v-alert>
      </div>

      <div class="d-flex justify-content-around">
        <v-btn
          v-if="method == 'edit'"
          primary
          class="btn-gold"
          @click="deleteShip()"
          >Excluir nave</v-btn
        >
        <v-btn
          primary
          class="btn-gold"
          @click="submit()"
          :loading="salvarAlteraçõesLoading"
          >{{ MethodBtn }}</v-btn
        >
      </div>
    </div>
  </div>
</template>

<script>
import DialogDelete from "../../components/DialogDelete.vue";
import DialogMessage from "../../components/DialogMessage.vue";
import DefaultService from "../../services/defaultService";
import PartsCrud from "../parts/PartsCrud.vue";
import useVuelidate from "@vuelidate/core";
import { required } from "@vuelidate/validators";
import SpaceShipTypeCrud from "../spaceshiptype/SpaceShipTypeCrud.vue";
export default {
  setup() {
    return { v$: useVuelidate( { $scope: false } ) };
  },
  data() {
    return {
      dialogLoaging: false,
      deleteLoading: false,
      salvarAlteraçõesLoading: false,
      itemsYear: [],
      year: null,
      CameFromcloseDialogOfSpaceShipType: false,
      Errors: 0,
      selected: [],
      dialogPart: false,
      PartsPerShip: {
        id: null,
        partsPerShipTypeId: 0,
        spaceShipId: 0,
        partId: 0,
        health: 0
      },
      MethodBtn: "",
      ErrorsSpaceShipType: 0,
      ErrorsParts: 0,
      dialogOptions: {
        title: "",
        dialog: false,
        message: "",
        type: "darken-2",
        botaoText: "",
      },
      title: "",
      dialogDelete: {
        dialog: false,
      },
      dialog: false,
      spaceshipTypeNamesCompare: null,
      partsNamesCompare: null,
      inputDisable: false,
      getPart: null,
      method: "create",
      ships: [],
     CameFromcloseDialogOfParts: false,
      desserts: [],
      Parts: {
        id: null,
        name: "",
        health: 0,
        description: "",   
      },
      shipsData: {
        id: null,
        name: "",
        color: "#1976D2FF",
        year: "",
        description: "",
        health: 1,
        statusfleetship: null,
        spaceShipTypeId: "",
        
      },
      spaceshipTypeNames: [],
      defaultService: null,
      getPartsPerShipType: null,
      getSpaceShipType: null,
      itemsStatus: [
        { text: "Inativa", value: 0 },
        { text: "Ativa", value: 1 },
        { text: "Em Manutenção", value: 2 },
      ],
      mask: "!#XXXXXXXX",
      menu: false,
      // checkbox: []
    };
  },
  computed: {
    swatchStyle() {
      const { menu } = this;
      return {
        backgroundColor: this.shipsData.color,
        cursor: "pointer",
        height: "30px",
        width: "30px",
        borderRadius: menu ? "50%" : "4px",
        transition: "border-radius 200ms ease-in-out",
      };
    },
  },

  // async created() {
  //   var Xmas = new Date().getFullYear();
  //   for (let i = Xmas; i >= 1900; i--){
  //     this.itemsYear.push(i)
  //   }
  //     this.setSpaceShipType()
  //   this.defaultService = new DefaultService(this.$http, 'ships');
  //   if (this.$route.name == "shipsEdit") {
  //     this.method = "update";
  //     this.MethodBtn = "Salvar alterações"
  //     this.load();
  //     this.getShipByID()
  //   }
  //   else if (this.$route.name == "shipsCreate") {
  //     this.method = "create";
  //     this.MethodBtn = "Cadastrar"
  //   }
  // },

  async created() {
    var Xmas = new Date().getFullYear();
    for (let i = Xmas; i >= 1900; i--) {
      this.itemsYear.push(i);
    }
    
    
    this.setSpaceShipType();
    this.setSelects();
    // this.setShipTypeByID();

    
    this.defaultService = new DefaultService(this.$http, "ships");
    
    if (this.$route.name == "shipsCreate") {
      this.method = "create";
      this.title = "Cadastro de Nave";
      this.MethodBtn = "Cadastrar";
    }
    if (this.$route.name == "shipsEdit") {
      this.method = "edit";
      this.title = "Editando a Nave";
      this.load();
      this.MethodBtn = "Salvar alterações";
      this.getShipByID();
    }
    if (this.$route.name == "shipRead") {
      this.method = "read";
      this.title = "Visualizando a Nave";
      this.inputDisable = true;
      this.getShipByID();
    }
    if (this.$route.name == "shipRead") {
      this.method = "read";
      this.title = "Mostrando a Nave";
      this.getShipByID();
    }
  },

  components: {PartsCrud, SpaceShipTypeCrud, DialogMessage, DialogDelete },

  validations() {
    return {
      shipsData: {
        name: { required },
        color: { required },
        year: { required },
        description: { required },
        spaceShipTypeId: { required },
      },
      PartsPerShip: {
        partsPerShipTypeId: { required },
        spaceShipId: { required },
        partId: { required },
        health: { required },
        
       
      },
    };
  },
  methods: {
    callback_dialog() {
      this.dialogOptions.dialog = false;
      this.deleteLoading = false;
      this.dialogLoaging = false;
      if (this.error) {
        this.salvarAlteraçõesLoading = false;
        // if (this.CameFromcloseDialogOfSpaceShipType == false && this.CameFromcloseDialogOfParts == false) {
        //   }
        return;
      }
      this.$router.push({ name: "shipsList" });
    },

    clean() {
      this.shipsData.name = "";
      this.shipsData.color = "#1976D2FF";
      this.shipsData.year = "";
      this.shipsData.description = "";
      this.shipsData.spaceShipTypeId = "";
      this.id = null;
    },

    closeDelete() {
      this.dialogDelete.dialog = false;
    },

    async deleteItemConfirm() {
      this.dialogLoaging = true;
      this.deleteLoading = true;
      this.defaultService
        .delete(this.shipsData)
        .then((res) => {
          this.dialogOptions.title = "Sucesso!";
          this.dialogOptions.message = "Item excluído com sucesso!";
          this.dialogOptions.type = "success";
          this.dialogOptions.botaoText = "Ok";
          this.dialogOptions.dialog = true;
          this.v$.$reset();
          this.deleteLoading = false;
          this.dialogLoaging = false;
          return res;
        })
        .catch((error) => {
          this.dialogOptions.title = "Falha no processamento!";
          this.dialogOptions.message = "Não foi possível excluir a nave!";
          this.dialogOptions.type = "error";
          this.dialogOptions.botaoText = "Tente Novamente";
          this.dialogOptions.dialog = true;
          this.error = true;
          return error;
        });
    },

    deleteShip() {
      this.dialogDelete.dialog = true;
    },

     close_dialogPart(event) {
      this.CameFromcloseDialogOfParts = true;
      this.setSelects();
      this.PartsPerShip.partId = event.data.id;
      this.dialogPart = false;
      // this.dialogOptions.dialog = true;
      this.dialogOptions.title = "Sucesso!";
      this.dialogOptions.message = "Item cadastrado com sucesso!";
      this.dialogOptions.type = "success";
      this.dialogOptions.botaoText = "Ok";
      // this.dialogOptions.dialog = true;
    },
    fechar_dialog(event) {
      this.CameFromcloseDialogOfSpaceShipType = true;
      this.setSpaceShipType();
      this.shipsData.spaceShipTypeId = event.data.id;
      this.dialog = false;
      // this.dialogOptions.dialog = true;
      this.dialogOptions.title = "Sucesso!";
      this.dialogOptions.message = "Item cadastrado com sucesso!";
      this.dialogOptions.type = "success";
      this.dialogOptions.botaoText = "Ok";
      // this.dialogOptions.dialog = true;
    },

    async getShipByID() {
      this.shipsData.id = this.$route.params.id;
      var shipByID = await this.defaultService.getById(this.shipsData.id);
      this.shipsData.name = shipByID.data.spaceShip.name;
      this.shipsData.color = shipByID.data.spaceShip.color;
      this.shipsData.year = shipByID.data.spaceShip.year;
      this.shipsData.description = shipByID.data.spaceShip.description;
      this.shipsData.spaceShipTypeId = shipByID.data.spaceShip.spaceShipType;
      
    },

    load() {
      this.id = this.$route.params.id;
      this.defaultService.getById(this.id).then((resp) => {
        this.shipsData.id = resp.data.spaceShip.id;
        this.shipsData.name = resp.data.spaceShip.name;
        this.shipsData.color = resp.data.spaceShip.color;
        this.shipsData.year = resp.data.spaceShip.year;
        this.shipsData.description = resp.data.spaceShip.description;
        this.shipsData.spaceShipTypeId = resp.data.spaceShip.spaceShipType;
      });
    },

    onContext(ctx) {
      // The date formatted in the locale, or the `label-no-date-selected` string
      this.formatted = ctx.selectedFormatted;
      // The following will be an empty string until a valid date is entered
      this.selected = ctx.selectedYMD;
    },


    async getAllPartsPerShipType(){
      
       var PartsshipService = new DefaultService(this.$http, "partsPerShipTypes");
      var partsshipstype = await PartsshipService.getAll();
       
      for (let i = 0; i < partsshipstype.data.length; i++) {
        if (this.PartsPerShip.partId == partsshipstype.data[i].partId) {
          this.getPartsPerShipType = partsshipstype.data[i].id;
        }
      }
      

    },
   

    async setSelects() {
      var efficiencyServiceParts = new DefaultService(this.$http, "parts");
      
      var parts = await efficiencyServiceParts.getAll();
      
      this.getPart = parts.data;
      
    },

    async setSpaceShipType() {
      var spaceshipService = new DefaultService(this.$http, "spaceshiptype");
      var shipstype = await spaceshipService.getAll();
      this.getSpaceShipType = shipstype.data;
    },



    async submit() {
      const isFormCorrect = await this.v$.$validate();

      this.getAllPartsPerShipType();

     

      this.ErrorsSpaceShipType = 0;
     

      this.v$.$errors.forEach((element) => {
        if (element.$propertyPath == "spaceShipType.name") {
          this.ErrorsSpaceShipType++;
        }
        if (element.$propertyPath == "spaceShipType.description") {
          this.ErrorsSpaceShipType++;
        }
      });
      if (this.v$.$errors.length - this.ErrorsSpaceShipType == 0) {
        //Caso houver erros do spaceshiptype
        this.salvarAlteraçõesLoading = true;
        // var spaceShip = {
        //   id: this.shipsData.id,
        //   description: this.shipsData.description,
        //   year: this.shipsData.year,
        //   color: this.shipsData.color,
        //   name: this.shipsData.name,
        //   spaceShipTypeId: this.shipsData.spaceShipTypeId.id,
        // };

        if (this.method == "create") {
          this.defaultService
            .post(this.shipsData)
            .then((res) => {
              this.error = false;
              this.dialogOptions.title = "Sucesso!";
              this.dialogOptions.message = "Item cadastrado com sucesso!";
              this.dialogOptions.type = "success";
              this.dialogOptions.botaoText = "Ok";
              this.dialogOptions.dialog = true;
              this.CameFromcloseDialogOfSpaceShipType = false;
              this.salvarAlteraçõesLoading = false;
              this.v$.$reset();

              

              var partsPerShip = {
                          partsPerShipTypeId: this.getPartsPerShipType,
                          // res.data.spaceShipType.partsPerShipType.id,
                          spaceShipId: res.data.id,
                          partId: this.PartsPerShip.partId,
                          health: res.data.health,
                        };
             
                        var PartsPerShipService = new DefaultService(this.$http, "partsPerShips");
                          PartsPerShipService.post(partsPerShip)
                          .then(() => {
                            this.error = false;
                            this.v$.$reset();
                          })
                          .catch((error) => {
                            this.error = true;
                            return error;
                          });
                          
            })
            .catch((error) => {
              this.dialogOptions.title = "Falha no processamento!";
              this.dialogOptions.message = "Não foi possível cadastrar a nave!";
              this.dialogOptions.type = "error";
              this.dialogOptions.botaoText = "Tente Novamente";
              this.dialogOptions.dialog = true;
              this.error = true;
              return error;
            });
            
        } else {

          

          this.defaultService
            .put(this.shipsData)
            .then((res) => {
              this.dialogOptions.title = "Sucesso!";
              this.dialogOptions.message = "Item editado com sucesso!";
              this.dialogOptions.type = "success";
              this.dialogOptions.botaoText = "Ok";
              this.dialogOptions.dialog = true;
              this.v$.$reset();
              this.salvarAlteraçõesLoading = false;

               var partsPerShip = {
                          partsPerShipTypeId: this.getPartsPerShipType,
                          // res.data.spaceShipType.partsPerShipType.id,
                          spaceShipId: res.data.id,
                          partId: this.PartsPerShip.partId,
                          health: res.data.health,
                        };
                        var PartsPerShipService = new DefaultService(this.$http, "partsPerShips");
                          PartsPerShipService.post(partsPerShip)
                          .then(() => {
                            this.error = false;
                            this.v$.$reset();
                          })
                          .catch((error) => {
                            this.error = true;
                            return error;
                          });

              return res;

              
              
            })
            .catch((error) => {
              this.dialogOptions.title = "Falha no processamento!";
              this.dialogOptions.message = "Não foi possível editar a nave!";
              this.dialogOptions.type = "error";
              this.dialogOptions.botaoText = "Tente Novamente";
              this.dialogOptions.dialog = true;
              this.error = true;
              return error;
            });
        }
       
      }else {
        return isFormCorrect;
      }
    },
  },
};
</script>
<style lang="scss" scoped>
@import "../../../src/assets/scss/index.scss";
</style>