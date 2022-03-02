<template >
  <div>
    <DialogMessage
      :dialogOptions="dialogOptions"
      @dialog_false="callback_dialog"
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
    <v-text-field
      :disabled="inputDisable"
      v-model="Parts.name"
      label="Nome"
    ></v-text-field>
    <div v-if="validateParts.Parts.name.$error">
      <v-alert border="bottom" color="pink darken-1" dark>
        O campo
        <strong>"Nome"</strong>
        não pode ficar vazio
      </v-alert>
    </div>

    <v-slider
      v-model="Parts.health"
      color="green"
      label="Vida"
      class="mt-8"
      min="1"
      max="100"
      thumb-label
    ></v-slider>
    <div v-if="validateParts.Parts.health.$error">
      <v-alert border="bottom" color="pink darken-1" dark>
        O campo
        <strong>"Vida"</strong>
        não pode ficar vazio
      </v-alert>
    </div>

     <v-row align="center">
        <v-col cols="11">
          <v-select
           
            label="Tipo"
            v-model="spaceShipType.id"
            :items="getSpaceShipType"
            item-text="name"
            item-value="id"
            sm="6"
          ></v-select>
        </v-col>
       
      </v-row>
      <!-- <div v-if="v$.spaceShipType.id.$error">
        <v-alert border="bottom" color="pink darken-1" dark>
          O campo
          <strong>"Tipo"</strong>
          não pode ficar vazio
        </v-alert>
      </div> -->

    <v-textarea
      :disabled="inputDisable"
      label="Descrição"
      auto-grow
      v-model="Parts.description"
    ></v-textarea>
    <div v-if="validateParts.Parts.description.$error">
      <v-alert border="bottom" color="pink darken-1" dark>
        O campo
        <strong>"Descrição"</strong>
        não pode ficar vazio
      </v-alert>
    </div>
    <div v-if="inputDisable == false" class="d-flex justify-content-around">
      <v-btn
        v-if="method == 'edit'"
        primary
        class="btn-gold mx-4"
        @click="deleteParts()"
        >Excluir peça</v-btn
      >
      <v-btn
        primary
        class="btn-gold mx-4"
        :loading="disableSaveLoadingBtn"
        @click="submit()"
        >{{ MethodBtn }}</v-btn
      >
    </div>
  </div>
</template>
<script>
import DialogMessage from "../../components/DialogMessage.vue";
import DialogDelete from "../../components/DialogDelete.vue";
import DefaultService from "../../services/defaultService.js";
import useVuelidate from "@vuelidate/core";
import { required } from "@vuelidate/validators";
// import SpaceShipTypeCrud from "../spaceshiptype/SpaceShipTypeCrud.vue";
export default {
  async created() {
    this.defaultService = new DefaultService(this.$http, "parts");
    
    this.setSpaceShipType();
    
    if (
      this.$route.name == "partsCreate" ||
      this.$route.name == "toolPerPartCreate" ||
      this.$route.name == "shipsCreate"
    ) {
      if (this.$route.name == "partsCreate") {
        this.title = "Cadastro de Peça";
      } else {
        this.title = "Criando uma Peça";
      }
      this.method = "create";
      this.MethodBtn = "Cadastrar";
    }
    
    if (this.$route.name == "partsEdit") {
      this.method = "edit";
      this.title = "Editando a Peça";
      this.MethodBtn = "Salvar alterações";
      this.getPartsByID();
      this.getSpaceShipTypeByID(); 
    }
    if (this.$route.name == "partsRead") {
      this.method = "read";
      this.title = "Visualizando a Peça";
      this.inputDisable = true;
      this.getPartsByID();
    }
    if (this.$route.name == "partsRead") {
      this.method = "read";
      this.title = "Mostrando a Peça";
      this.getPartsByID();
    }
  },
  setup() {
    return { validateParts: useVuelidate( { $scope: false } ) };
  },
  data() {
    return {
      deleteLoading: false,
      disableSaveLoadingBtn: false,
      defaultService: null,
      inputDisable: false,
      method: null,
      title: "",
      Errors: 0,
      Parts: {
        id: null,
        name: "",
        health: 0,
        description: "",
      },
      spaceShipType: {
        id: null,
        name: "",
        description: "",
        countSpaceShip: 0,
      },
      CameFromcloseDialogOfSpaceShipType: false,
      ErrorsSpaceShipType: 0,
      spaceshipTypeNamesCompare: null,
      spaceshipTypeNames: [],
      partsPerShips: {
        partsPerShipTypeId: 0,
        spaceShipId: 0,
        partId: 0
      },
      MethodBtn: "",
      selectSpaceShip: null,
      items: [],
      tools: null,
      dialogOptions: {
        title: "",
        dialog: false,
        message: "",
        type: "darken-2",
        botaoText: "",
      },
      dialog: false,
      dialogLoaging: false,
      dialogDelete: {
        dialog: false,
      },
      dialogShip: false,
      getShip: null,
      getSpaceShipType: null,
      CameFromcloseDialogOfShip: false
    };
  },
  components: {
    DialogMessage,
    DialogDelete,
    // SpaceShipTypeCrud
  },
  validations() {
    return {
      Parts: {
        name: { required },
        health: { required },
        description: { required },
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
        return;
      }
      this.$router.push({ name: "partsList" });
      
        
      
    },

    clearInputs() {
      Object.keys(this.Parts).forEach((key) => {
        this.Parts[key] = "";
      });
    },

    closeDelete() {
      this.dialogDelete.dialog = false;
    },

    deleteItemConfirm() {
      this.deleteLoading = true;
      this.dialogLoaging = true;
      this.defaultService
        .delete(this.Parts)
        .then((res) => {
          this.dialogOptions.title = "Sucesso!";
          this.dialogOptions.message = "Item excluído com sucesso!";
          this.dialogOptions.type = "success";
          this.dialogOptions.botaoText = "Ok";
          this.dialogOptions.dialog = true;
          this.validateParts.$reset();
          this.deleteLoading = false;
          this.dialogLoaging = false;
          return res;
        })
        .catch((error) => {
          this.dialogOptions.title = "Falha no processamento!";
          this.dialogOptions.message = "Não foi possível excluir a peça!";
          this.dialogOptions.type = "error";
          this.dialogOptions.botaoText = "Tente Novamente";
          this.dialogOptions.dialog = true;
          this.error = true;
          return error;
        });
    },

    async deleteParts() {
      this.dialogDelete.dialog = true;
    },

    async setSpaceShipType() {
      var spaceshipService = new DefaultService(this.$http, "spaceshiptype");
      var shipstype = await spaceshipService.getAll();
      this.getSpaceShipType = shipstype.data;
    },


   

    async getPartsByID() {
      this.Parts.id = this.$route.params.id;
      var partsByID = await this.defaultService.getById(this.Parts.id);
      this.Parts.name = partsByID.data.part.name;
      this.Parts.health = partsByID.data.part.health;
      this.Parts.description = partsByID.data.part.description;
    },


    async submit() {
      const isFormCorrect = await this.validateParts.$validate();
      if (!isFormCorrect) {
        return isFormCorrect;
      } else {
        if (this.validateParts.$errors.length - this.Errors == 0) {


          
        

          //Caso houver erros do spaceshiptype
          this.disableSaveLoadingBtn = true;
          if (this.method == "create" || this.method == null) {
            


            this.defaultService
              .post(this.Parts)
              .then((res) => {
                
                
                if (this.$route.name == "toolPerPartCreate") {
                  this.$emit("cadastro_de_peca", res);
                  this.clearInputs();
                }
                 if (this.$route.name == "shipsCreate") {
                  this.$emit("cadastro_de_peca", res);
                  this.clearInputs();
                }
                if (this.$route.name == "partsCreate") {
                  this.error = false;
                  this.dialogOptions.title = "Sucesso!";
                  this.dialogOptions.message = "Item cadastrado com sucesso!";
                  this.dialogOptions.type = "success";
                  this.dialogOptions.botaoText = "Ok";
                  this.dialogOptions.dialog = true;
                }
                this.disableSaveLoadingBtn = false;
                this.validateParts.$reset();

                var partsPerShipType = {
                        amount: 0,
                        partId: res.data.id,
                        spaceShipTypeId: this.spaceShipType.id,
                      };
                      
                  
                      var PartsPerShipTypeService = new DefaultService(this.$http, "partsPerShipTypes");
                        PartsPerShipTypeService.post(partsPerShipType)
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
                this.dialogOptions.message = "Não foi possível cadastrar peça!";
                this.dialogOptions.type = "error";
                this.dialogOptions.botaoText = "Tente Novamente";
                this.dialogOptions.dialog = true;
                this.error = true;
                return error;
              });
              
          } else {

            var partsPerShipType = {
                          amount: 0,
                          partId: this.Parts.id,
                          spaceShipTypeId: this.spaceShipType.id,
                        };
              

            var PartsPerShipTypeService = new DefaultService(this.$http, "partsPerShipTypes");
              PartsPerShipTypeService.post(partsPerShipType)
              .then(() => {
                this.error = false;
                this.validateParts.$reset();
              })
              .catch((error) => {
                this.error = true;
                return error;
              });

            this.defaultService
              .put(this.Parts)
              .then((res) => {
                this.dialogOptions.title = "Sucesso!";
                this.dialogOptions.message = "Item editado com sucesso!";
                this.dialogOptions.type = "success";
                this.dialogOptions.botaoText = "Ok";
                this.dialogOptions.dialog = true;
                this.validateParts.$reset();
                this.disableSaveLoadingBtn = false;
                return res;
              })
              .catch((error) => {
                this.dialogOptions.title = "Falha no processamento!";
                this.dialogOptions.message = "Não foi possível editar a peça!";
                this.dialogOptions.type = "error";
                this.dialogOptions.botaoText = "Tente Novamente";
                this.dialogOptions.dialog = true;
                this.error = true;
                return error;
              });
          }
        }
      }
    },
  },
};
</script>
<style  lang="scss" scoped>
@import "../../assets/scss/index.scss";
</style>