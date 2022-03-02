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
      :deleteLoading="deleteLoading"
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
      v-model="spaceShipType.name"
      label="Nome"
    ></v-text-field>
    <div v-if="v$.spaceShipType.name.$error">
      <v-alert border="bottom" color="pink darken-1" dark>
        O campo
        <strong>"Nome"</strong>
        não pode ficar vazio
      </v-alert>
    </div>

    <v-textarea
      :disabled="inputDisable"
      label="Descrição"
      auto-grow
      v-model="spaceShipType.description"
    ></v-textarea>
    <div v-if="v$.spaceShipType.description.$error">
      <v-alert border="bottom" color="pink darken-1" dark>
        O campo
        <strong>"Descrição"</strong>
        não pode ficar vazio
      </v-alert>
    </div>
    <div v-if="inputDisable == false" class="d-flex justify-content-around">
      <v-btn
        v-if="method == 'edit' && spaceShipTypeCount == 0"
        primary
        class="btn-gold"
        @click="deleteSpaceShipType"
        >Excluir tipo de nave</v-btn
      >
      <v-btn
        primary
        class="btn-gold"
        :loading="disableSaveLoading"
        @click="submit"
      >
        <div v-if="this.method != null">{{ MethodBtn }}</div>
        <div v-else>Cadastrar</div>
      </v-btn>
    </div>
  </div>
</template>
<script>
import DialogDelete from "../../components/DialogDelete.vue";
import DialogMessage from "../../components/DialogMessage.vue";
import DefaultService from "../../services/defaultService.js";
import useVuelidate from "@vuelidate/core";
import { required } from "@vuelidate/validators";
export default {
  setup() {
    return {
      v$: useVuelidate( { $scope: false } ),
    };
  },
  async created() {
    this.defaultService = new DefaultService(this.$http, "spaceshiptype");

    if (
      this.$route.name == "spaceshiptypeCreate" ||
      this.$route.name == "shipsCreate"
    ) {
      this.method = "create";
      this.MethodBtn = "Cadastrar";
      if (this.$route.name == "spaceshiptypeCreate") {
        this.title = "Cadastro de Tipo de Nave";
      } else {
        this.title = "Criando um tipo de nave";
      }
    }
    if (this.$route.name == "spaceshiptypeEdit") {
      this.method = "edit";
      this.title = "Editando o tipo de nave";
      this.MethodBtn = "Salvar alterações";
      this.getSpaceShipTypeByID();
      this.getCountSpaceShipType();
    }
    if (this.$route.name == "spaceshiptypeRead") {
      this.method = "read";
      this.title = "Visualizando o tipo de nave";
      this.inputDisable = true;
      this.getSpaceShipTypeByID();
    }
    if (this.$route.name == "spaceshiptypeRead") {
      this.method = "read";
      this.title = "Mostrando o tipo de nave";
    }
  },
  data() {
    return {
      dialogLoaging: false,
      deleteLoading: false,
      disableSaveLoading: false,
      serverError: false,
      Errors: 0,
      inputDisable: false,
      method: null,
      title: "",
      test: 0,
      spaceShipType: {
        id: null,
        name: "",
        description: "",
        countSpaceShip: 0,
      },
    
      spaceShipTypeCount: 0,
      count: {},
      MethodBtn: "",
      selectSpaceShip: null,
      items: [],
      spaceShips: null,
      defaultService: null,
      dialogOptions: {
        title: "",
        dialog: false,
        message: "",
        type: "darken-2",
        botaoText: "",
      },
      dialogDelete: {
        dialog: false,
      },
    };
  },
  components: {
    DialogMessage,
    DialogDelete,
  },
  validations() {
    return {
      spaceShipType: {
        name: { required },
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
        this.disableSaveLoading = false;
        return;
      }
      if(this.$route.name == 'shipsCreate'){
        return
      }
      this.$router.push({ name: "spaceshiptypeList" });
    },

    clearInputs() {
      Object.keys(this.spaceShipType).forEach((key) => {
        this.spaceShipType[key] = "";
      });
    },

    closeDelete() {
      this.dialogDelete.dialog = false;
    },

    async deleteItemConfirm() {
      this.dialogLoaging = true;
      this.deleteLoading = true;
      this.defaultService
        .delete(this.spaceShipType)
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
          this.dialogOptions.message =
            "Não foi possível excluir o tipo de nave!";
          this.dialogOptions.type = "error";
          this.dialogOptions.botaoText = "Tente Novamente";
          this.dialogOptions.dialog = true;
          this.error = true;
          return error;
        });
    },

    async deleteSpaceShipType() {
      this.dialogDelete.dialog = true;
    },

   

    async getCountSpaceShipType() {
      this.count = await this.defaultService.getCount();
      let a = this.spaceShipType.id;
      this.test = a;
      for (let i = 0; i < this.count.data.length; i++) {
        if (a == this.count.data[i].id) {
          this.spaceShipTypeCount = this.count.data[i].countSpaceShip;
        }
      }
    },

    async getSpaceShipTypeByID() {
      this.spaceShipType.id = this.$route.params.id;
      var shipByID = await this.defaultService.getById(this.spaceShipType.id);
      this.spaceShipType.name = shipByID.data.spaceShipType.name;
      this.spaceShipType.description = shipByID.data.spaceShipType.description;
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

    async submit() {
      const isFormCorrect = await this.v$.$validate();
      if (this.spaceShipType.id) {
        if (!isFormCorrect) {
          return isFormCorrect;
        } else {
          this.disableSaveLoading = true;
          this.defaultService
            .put(this.spaceShipType)
            .then((res) => {
              this.dialogOptions.title = "Sucesso!";
              this.dialogOptions.message = "Item editado com sucesso!";
              this.dialogOptions.type = "success";
              this.dialogOptions.botaoText = "Ok";
              this.dialogOptions.dialog = true;
              this.v$.$reset();
              this.disableSaveLoading = false;
              return res;
            })
            .catch((error) => {
              this.dialogOptions.title = "Falha no processamento!";
              this.dialogOptions.message =
                "Não foi possível editar o tipo de nave!";
              this.dialogOptions.type = "error";
              this.dialogOptions.botaoText = "Tente Novamente";
              this.dialogOptions.dialog = true;
              this.error = true;
              return error;
            });
        }
      }

      if (!isFormCorrect) {
        return isFormCorrect;
      } else {
        
        if (this.method == "create" || this.method == null) {
          this.disableSaveLoading = true;
          this.defaultService
            .post(this.spaceShipType)
            .then((res) => {
              if (this.$route.name == "shipsCreate") {
                this.$emit("cadastro_de_tipo_de_nave", res);
                this.clearInputs();
              }

              if (this.$route.name == "spaceshiptypeCreate") {
                this.serverError = false;
                this.dialogOptions.title = "Sucesso!";
                this.dialogOptions.message = "Item cadastrado com sucesso!";
                this.dialogOptions.type = "success";
                this.dialogOptions.botaoText = "Ok";
                this.dialogOptions.dialog = true;
              }
              this.disableSaveLoading = false;
              this.v$.$reset();
            })
            .catch((error) => {
              this.serverError = true;
              this.dialogOptions.title = "Falha no processamento!";
              this.dialogOptions.message =
                "Não foi possível cadastrar o tipo de nave!";
              this.dialogOptions.type = "error";
              this.dialogOptions.botaoText = "Tente Novamente";
              this.dialogOptions.dialog = true;
              this.error = true;
              return error;
            });
        }
      }
    },
  },
};
</script>
<style  lang="scss" scoped>
@import "../../assets/scss/index.scss";
</style>