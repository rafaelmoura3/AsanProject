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
      v-model="tools.name"
      label="Nome"
    ></v-text-field>
    <div v-if="validateToolCrud.tools.name.$error">
      <v-alert border="bottom" color="pink darken-1" dark>
        O campo
        <strong>"Nome"</strong>
        não pode ficar vazio
      </v-alert>
    </div>
    <div v-if="inputDisable == false" class="d-flex justify-content-around">
      <v-btn
        v-if="method == 'edit'"
        primary
        class="btn-gold"
        @click="deletetools"
        >Excluir Ferramenta</v-btn
      >
      <v-btn
        primary
        class="btn-gold"
        :loading="disableSaveLoading"
        @click="submit"
        >{{ MethodBtn }}</v-btn
      >
    </div>
  </div>
</template>
<script>
import DialogDelete from "../../components/DialogDelete.vue";
import DialogMessage from "../../components/DialogMessage.vue";
import useVuelidate from "@vuelidate/core";
import { required } from "@vuelidate/validators";
import DefaultService from "../../services/defaultService";
export default {
  setup() {
    return { validateToolCrud: useVuelidate( { $scope: false }) };
  },
  created() {
    this.defaultService = new DefaultService(this.$http, "tools");

    if (
      this.$route.name == "toolsCreate" ||
      this.$route.name == "toolPerPartCreate"
    ) {
      if (this.$route.name == "toolsCreate") {
        this.title = "Cadastro de Ferramenta";
      } else {
        this.title = "Criando uma ferramenta";
      }
      this.method = "create";
      this.MethodBtn = "Cadastrar";
    }
    if (this.$route.name == "toolsRead") {
      this.title = "Visualizando a Ferramenta";
      this.method = "read";
      this.inputDisable = true;
      this.tools.id = this.$route.params.id;
      this.getToolById();
    }
    if (this.$route.name == "toolsEdit") {
      this.title = "Editando a Ferramenta";
      this.MethodBtn = "Salvar alteração";
      this.method = "edit";
      
      this.inputDisable = false;
      this.getToolById();
    }
  },
  data() {
    return {
      deleteLoading: false,
      disableSaveLoading: false,
      inputDisable: false,
      Errors: 0,
      tools: {
        id: null,
        name: "",
      },

      title: null,
      method: "",
      defaultService: null,

      dialogOptions: {
        title: "",
        dialog: false,
        message: "",
        type: "darken-2",
        botaoText: "",
      },
      dialogLoaging: false,
      dialogDelete: {
        dialog: false,
      },
      estilo: "",
    };
  },
  components: {
    DialogMessage,
    DialogDelete,
  },
  validations() {
    return {
      tools: {
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
        this.disableSaveLoading = false;
        return;
      }
      this.$router.push({ name: "toolsList" });
    },

    clearInputs() {
      Object.keys(this.tools).forEach((key) => {
        this.tools[key] = "";
      });
    },

    closeDelete() {
      this.dialogDelete.dialog = false;
    },

    async deleteItemConfirm() {
      this.dialogLoaging = true;
      this.deleteLoading = true;
      this.defaultService
        .delete(this.tools)
        .then((res) => {
          this.dialogOptions.title = "Sucesso!";
          this.dialogOptions.message = "Item excluído com sucesso!";
          this.dialogOptions.type = "success";
          this.dialogOptions.botaoText = "Ok";
          this.dialogOptions.dialog = true;
          this.validateToolCrud.$reset();
          this.deleteLoading = false;
          this.dialogLoaging = false;
          return res;
        })
        .catch((error) => {
          this.dialogOptions.title = "Falha no processamento!";
          this.dialogOptions.message = "Não foi possível excluir a ferramenta!";
          this.dialogOptions.type = "error";
          this.dialogOptions.botaoText = "Tente Novamente";
          this.dialogOptions.dialog = true;
          this.error = true;
          return error;
        });
    },

    async deletetools() {
      this.dialogDelete.dialog = true;
    },

    async getToolById() {
      this.tools.id = this.$route.params.id;
      var Tool = await this.defaultService.getById(this.tools.id);
      this.tools.name = Tool.data.tool.name;
    },

    

    async submit() {
      const isFormCorrect = await this.validateToolCrud.$validate();
      if (!isFormCorrect) {
        return isFormCorrect;
      } else {
        if (this.validateToolCrud.$errors.length - this.Errors == 0) {
          //Caso houver erros do spaceshiptype
          this.disableSaveLoading = true;
          if (this.method == "create" || this.method == null) {
            this.defaultService
              .post(this.tools)
              .then((res) => {
                if (this.$route.name == "toolPerPartCreate") {
                  this.$emit("cadastro_de_ferramenta", res);
                  this.clearInputs();
                }
                if (this.$route.name == "toolsCreate") {
                  this.error = false;
                  this.dialogOptions.title = "Sucesso!";
                  this.dialogOptions.message = "Item cadastrado com sucesso!";
                  this.dialogOptions.type = "success";
                  this.dialogOptions.botaoText = "Ok";
                  this.dialogOptions.dialog = true;
                }
                  this.validateToolCrud.$reset();
                console.log(this.validateToolCrud.$reset());
                this.disableSaveLoading = false;
                
              })
              .catch((error) => {
                this.dialogOptions.title = "Falha no processamento!";
                this.dialogOptions.message =
                  "Não foi possível cadastrar a ferramenta!";
                this.dialogOptions.type = "error";
                this.dialogOptions.botaoText = "Tente Novamente";
                this.dialogOptions.dialog = true;
                this.error = true;
                return error;
              });
          } else {
            this.defaultService
              .put(this.tools)
              .then((res) => {
                this.dialogOptions.title = "Sucesso!";
                this.dialogOptions.message = "Item editado com sucesso!";
                this.dialogOptions.type = "success";
                this.dialogOptions.botaoText = "Ok";
                this.dialogOptions.dialog = true;
                this.validateToolCrud.$reset();
                this.disableSaveLoading = false;
                return res;
              })
              .catch((error) => {
                this.dialogOptions.title = "Falha no processamento!";
                this.dialogOptions.message =
                  "Não foi possível editar a ferramenta!";
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