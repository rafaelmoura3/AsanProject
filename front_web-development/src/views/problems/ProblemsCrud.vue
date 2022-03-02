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

    <form>
      <div class="d-flex justify-center titulo">{{ title }}</div>
      <div>
        <v-text-field
          type="text"
          :disabled="inputsDisabled"
          v-model="Problems.name"
          class="mt-10"
          label="Nome"
        ></v-text-field>
        <div v-if="v$.Problems.name.$error">
          <v-alert border="bottom" color="pink darken-1" dark>
            O campo
            <strong>"Nome"</strong>
            não pode ficar vazio
          </v-alert>
        </div>
      </div>
      <center v-if="method != 'read'" class="d-flex justify-content-around">
        <v-btn
          v-if="method == 'edit'"
          primary
          class="btn-gold"
          @click="excluirProblema"
          >Excluir problema</v-btn
        >
        <v-btn
          primary
          class="btn-gold"
          :loading="salvarAlteraçõesLoading"
          @click="createProblems"
          >{{ titleBtnSubmit }}</v-btn
        >
      </center>
    </form>
  </div>
</template>
<script>
import DialogDelete from "../../components/DialogDelete.vue";
import DialogMessage from "../../components/DialogMessage.vue";
import useVuelidate from "@vuelidate/core";
import { required } from "@vuelidate/validators";
import DefaultService from "../../services/defaultService";
export default {
  async created() {
    
    this.defaultService = new DefaultService(this.$http, "problems");
    if (this.$route.name == "problemsCreate") {
      this.title = "Cadastro de Problema";
      this.titleBtnSubmit = "Cadastrar";
      this.method = "create";
    }

    if (this.$route.name == "problemsEdit") {
      this.method = "edit";
      this.title = "Editando Problemas";
      this.titleBtnSubmit = "Salvar alterações";
      this.load();
      this.getProblemsByID();
    }
    if (this.$route.name == "problemsRead") {
      this.method = "read";
      this.title = "Visualizando Problemas";
      this.inputDisable = true;
      this.getProblemsByID();
    }
    if (this.$route.name == "problemsRead") {
      this.method = "read";
      this.title = "Mostrando Problemas";
      this.getProblemsByID();
    }
  },
  setup() {
    return { v$: useVuelidate() };
  },
  data() {
    return {
      dialogLoaging: false,
      deleteLoading: false,
      salvarAlteraçõesLoading: false,
      inputsDisabled: false,
      method: null,
      title: "",
      Errors: 0,
      titleBtnSubmit: null,
      defaultService: null,
      Problems: {
        id: null,
        name: "",
      },
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
      Problems: {
        name: { required },
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
      this.$router.push({ name: "problemsList" });
    },

    closeDelete() {
      this.dialogDelete.dialog = false;
    },

    async createProblems() {
      const isFormCorrect = await this.v$.$validate();
      if (!isFormCorrect) {
        return isFormCorrect;
      } else {
        if (this.v$.$errors.length - this.Errors == 0) {
          //Caso houver erros do spaceshiptype
          this.salvarAlteraçõesLoading = true;
          if (this.method == "create") {
            this.defaultService
              .post(this.Problems)
              .then(() => {
                this.error = false;
                this.dialogOptions.title = "Sucesso!";
                this.dialogOptions.message = "Item cadastrado com sucesso!";
                this.dialogOptions.type = "success";
                this.dialogOptions.botaoText = "Ok";
                this.dialogOptions.dialog = true;
                this.salvarAlteraçõesLoading = false;

                this.v$.$reset();
              })
              .catch((error) => {
                this.dialogOptions.title = "Falha no processamento!";
                this.dialogOptions.message =
                  "Não foi possível cadastrar o problema!";
                this.dialogOptions.type = "error";
                this.dialogOptions.botaoText = "Tente Novamente";
                this.dialogOptions.dialog = true;
                this.error = true;
                return error;
              });
          } else {
            this.defaultService
              .put(this.Problems)
              .then((res) => {
                this.dialogOptions.title = "Sucesso!";
                this.dialogOptions.message = "Item editado com sucesso!";
                this.dialogOptions.type = "success";
                this.dialogOptions.botaoText = "Ok";
                this.dialogOptions.dialog = true;
                this.v$.$reset();
                this.salvarAlteraçõesLoading = false;
                return res;
              })
              .catch((error) => {
                this.dialogOptions.title = "Falha no processamento!";
                this.dialogOptions.message =
                  "Não foi possível editar o problema!";
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

    deleteItemConfirm() {
      this.dialogLoaging = true;
      this.deleteLoading = true;
      this.defaultService
        .delete(this.Problems)
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
          this.dialogOptions.message = "Não foi possível excluir o problema!";
          this.dialogOptions.type = "error";
          this.dialogOptions.botaoText = "Tente Novamente";
          this.dialogOptions.dialog = true;
          this.error = true;
          return error;
        });
    },

    excluirProblema() {
      this.dialogDelete.dialog = true;
    },

    async getProblemsByID() {
      this.Problems.id = this.$route.params.id;
      var problemsByID = await this.defaultService.getById(this.Problems.id);
      this.Problems.name = problemsByID.data.problem.name;
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
  },
};
</script>

<style  lang="scss" scoped>
@import "../../assets/scss/index.scss";
</style>
