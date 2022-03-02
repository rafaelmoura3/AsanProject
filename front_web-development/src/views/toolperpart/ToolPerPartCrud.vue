<template>
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

    <v-row align="center">
      <v-col cols="11">
        <v-select
          label="Peça"
          v-model="efficiencyData.partId"
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
    <div v-if="validateToolPerPartCrud.efficiencyData.partId.$error">
      <v-alert border="bottom" color="pink darken-1" dark>
        O campo
        <strong>"Peça"</strong>
        não pode ficar vazio
      </v-alert>
    </div>

    <v-row align="center">
      <v-col cols="11">
        <v-select
          label="Ferramenta"
          v-model="efficiencyData.toolId"
          :items="getTool"
          item-text="name"
          item-value="id"
          sm="6"
        ></v-select>
      </v-col>
      <v-col cols="1" align="right">
        <v-dialog v-model="dialogTool" width="500">
          <template v-slot:activator="{ on, attrs }">
            <v-btn class="btn-gold" dark fab small v-bind="attrs" v-on="on">
              <v-icon dense>mdi-plus</v-icon>
            </v-btn>
          </template>
          <v-card>
            <v-container>
              <ToolsCrud @cadastro_de_ferramenta="close_dialogTool($event)" />
            </v-container>
          </v-card>
        </v-dialog>
      </v-col>
    </v-row>
    <div v-if="validateToolPerPartCrud.efficiencyData.toolId.$error">
      <v-alert border="bottom" color="pink darken-1" dark>
        O campo
        <strong>"Ferramenta"</strong>
        não pode ficar vazio
      </v-alert>
    </div>

    <v-row align="center">
      <v-col cols="12">
        <v-select
          :items="itemsPercent"
          v-model="efficiencyData.efficiency"
          label="Porcentagem"
        ></v-select>
      </v-col>
    </v-row>
    <div v-if="validateToolPerPartCrud.efficiencyData.efficiency.$error">
      <v-alert border="bottom" color="pink darken-1" dark>
        O campo
        <strong>"Porcentagem"</strong>
        não pode ficar vazio
      </v-alert>
    </div>

    <div class="d-flex justify-content-around">
      <v-btn
        v-if="method == 'edit'"
        primary
        class="btn-gold"
        @click="deleteEfficiency()"
        >Excluir Eficiência</v-btn
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
</template>
<script>
import DialogDelete from "../../components/DialogDelete.vue";
import DialogMessage from "../../components/DialogMessage.vue";
import DefaultService from "../../services/defaultService";
import PartsCrud from "../parts/PartsCrud.vue";
import ToolsCrud from "../tools/ToolsCrud.vue";
import useVuelidate from "@vuelidate/core";
import { required } from "@vuelidate/validators";

export default {
  setup() {
    return { validateToolPerPartCrud: useVuelidate( { $scope: false } ) };
  },
  created() {
    var percent = 0;
    for (let i = percent; i <= 100; i++) {
      this.itemsPercent.push(i);
    }
    this.setSelects();
    this.defaultService = new DefaultService(this.$http, "toolperpart");
    if (this.$route.name == "toolPerPartCreate") {
      this.title = "Eficiência da Ferramenta";
      this.method = "create";
      this.MethodBtn = "Cadastrar";
    }
    if (this.$route.name == "toolPerPartRead") {
      this.title = "Visualizando a Eficiência";
      this.method = "read";
      this.inputDisable = true;
      this.tools.id = this.$route.params.id;
      this.getEfficiencyById();
    }
    if (this.$route.name == "toolPerPartEdit") {
      this.title = "Editando a Eficiência";
      this.MethodBtn = "Salvar alterações";
      this.method = "edit";
      this.load();
      this.inputDisable = false;
      this.tools.id = this.$route.params.id;

      this.getEfficiencyById();
    }
  },

  data() {
    return {
      deleteLoading: false,
      salvarAlteraçõesLoading: false,
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
      dialogTool: false,
      dialogPart: false,
      efficiencyData: {
        id: null,
        efficiency: null,
        toolId: null,
        partId: null,
      },
      getTool: null,
      getPart: null,
      itemsPercent: [],
      CameFromcloseDialogOfTools: false,
      CameFromcloseDialogOfParts: false,
      Errors: 0,
    };
  },

  components: {
    PartsCrud,
    ToolsCrud,
    DialogMessage,
    DialogDelete,
  },

  validations() {
    return {
      efficiencyData: {
        efficiency: { required },
        toolId: { required },
        partId: { required },
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
      if (this.CameFromcloseDialogOfTools == false && this.CameFromcloseDialogOfParts == false) {
        this.$router.push({ name: "toolPerPartList" });
      }
    },

    clean() {
      (this.id = null),
        (this.efficiencyData.efficiency = ""),
        (this.efficiencyData.toolId = ""),
        (this.efficiencyData.partId = "");
    },

    closeDelete() {
      this.dialogDelete.dialog = false;
    },

    close_dialogPart(event) {
      this.CameFromcloseDialogOfParts = true;
      this.setSelects();
      
      console.log("close_dialogPart" , event);
      this.efficiencyData.partId = event.data.id;
      this.dialogPart = false;
      this.dialogOptions.dialog = true;
      this.dialogOptions.title = "Sucesso!";
      this.dialogOptions.message = "Item cadastrado com sucesso!";
      this.dialogOptions.type = "success";
      this.dialogOptions.botaoText = "Ok";
      this.dialogOptions.dialog = true;
    },
    
    close_dialogTool(event) {
      this.CameFromcloseDialogOfTools = true;
      this.setSelects();
      console.log("close_dialogTool" , event);
      this.efficiencyData.toolId = event.data.id;
      this.dialogTool = false;
      this.dialogOptions.dialog = true;
      this.dialogOptions.title = "Sucesso!";
      this.dialogOptions.message = "Item criado com sucesso!";
      this.dialogOptions.type = "success";
      this.dialogOptions.botaoText = "Ok";
      this.dialogOptions.dialog = true;
    },

    async deleteItemConfirm() {
      this.dialogLoaging = true;
      this.deleteLoading = true;
      this.defaultService
        .delete(this.efficiencyData)
        .then((res) => {
          this.dialogOptions.title = "Sucesso!";
          this.dialogOptions.message = "Item excluído com sucesso!";
          this.dialogOptions.type = "success";
          this.dialogOptions.botaoText = "Ok";
          this.dialogOptions.dialog = true;
          this.validateToolPerPartCrud.$reset();
          this.deleteLoading = false;
          this.dialogLoaging = false;
          return res;
        })
        .catch((error) => {
          this.dialogOptions.title = "Falha no processamento!";
          this.dialogOptions.message = "Não foi possível excluir a eficiência!";
          this.dialogOptions.type = "error";
          this.dialogOptions.botaoText = "Tente Novamente";
          this.dialogOptions.dialog = true;
          this.error = true;
          return error;
        });
    },

    deleteEfficiency() {
      this.dialogDelete.dialog = true;
    },

    async getEfficiencyById() {
      this.efficiencyData.id = this.$route.params.id;
      var efficiencyByID = await this.defaultService.getById(this.efficiencyData.id);
      this.efficiencyData.efficiency = efficiencyByID.data.toolperpart.efficiency;
      this.efficiencyData.toolId = efficiencyByID.data.toolperpart.toolId;
      this.efficiencyData.partId = efficiencyByID.data.toolperpart.partId;
    },

    load() {
      this.id = this.$route.params.id;
      this.defaultService.getById(this.id).then((resp) => {
        console.log(resp);
        this.efficiencyData.id = resp.data.toolperpart.id;
        this.efficiencyData.toolId = resp.data.toolperpart.toolId;
        this.efficiencyData.partId = resp.data.toolperpart.partId;
        this.efficiencyData.efficiency = resp.data.toolperpart.efficiency;
      });
    },

    async setSelects() {
      var efficiencyServiceParts = new DefaultService(this.$http, "parts");
      var efficiencyServiceTools = new DefaultService(this.$http, "tools");
      var parts = await efficiencyServiceParts.getAll();
      var tools = await efficiencyServiceTools.getAll();
      this.getPart = parts.data;
      this.getTool = tools.data;
    },

    async submit() {
      const isFormCorrect = await this.validateToolPerPartCrud.$validate();
      console.log(this.validateToolPerPartCrud);
      if (!isFormCorrect) {
        console.log(this.efficiencyData.partId);
        return isFormCorrect;
      } else {
        
        if (this.method == "create") {
          this.salvarAlteraçõesLoading = true;
          console.log("create" , this.efficiencyData);
          this.defaultService
            .post(this.efficiencyData)
            .then(() => {
              this.error = false;
              this.dialogOptions.title = "Sucesso!";
              this.dialogOptions.message = "Item cadastrado com sucesso!";
              this.dialogOptions.type = "success";
              this.dialogOptions.botaoText = "Ok";
              this.dialogOptions.dialog = true;
              this.CameFromcloseDialogOfTools = false;
              this.CameFromcloseDialogOfParts = false;
              this.salvarAlteraçõesLoading = false;
              this.validateToolPerPartCrud.$reset();
              
            })
            .catch((error) => {
              this.dialogOptions.title = "Falha no processamento!";
              this.dialogOptions.message =
                "Não foi possível cadastrar a eficiência!";
              this.dialogOptions.type = "error";
              this.dialogOptions.botaoText = "Tente Novamente";
              this.dialogOptions.dialog = true;
              this.error = true;
              return error;
            });
        } else {
          this.defaultService
            .put(this.efficiencyData)
            .then((res) => {
              this.dialogOptions.title = "Sucesso!";
              this.dialogOptions.message = "Item editado com sucesso!";
              this.dialogOptions.type = "success";
              this.dialogOptions.botaoText = "Ok";
              this.dialogOptions.dialog = true;
              this.validateToolPerPartCrud.$reset();
              this.salvarAlteraçõesLoading = false;
              return res;
            })
            .catch((error) => {
              this.dialogOptions.title = "Falha no processamento!";
              this.dialogOptions.message =
                "Não foi possível editar a eficiência!";
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
<style lang="scss" scoped>
@import "../../assets/scss/index.scss";
</style>