<template >
  <div>
    <div class="d-flex justify-content-center titulo">Lista de Ferramentas</div>
    <v-data-table
      :headers="headers"
      :items="desserts"
      :footer-props="{
        'items-per-page-text': 'Ferramentas por página:',
        pageText: '{0}-{1} de {2}',
      }"
      sort-by="calories"
      class="elevation-1"
    >
      <template v-slot:top>
        <v-toolbar flat>
          <v-divider class="mx-4" inset vertical></v-divider>
          <v-spacer></v-spacer>
          <v-btn dark class="mb-2 btn-gold" @click="newItem"
            >Criar uma nova ferramenta</v-btn
          >
          <v-dialog v-model="dialogDelete" max-width="500px">
            <v-card>
              <v-card-title class="body-style d-flex justify-center"
                >Deseja excluir este item?</v-card-title
              >
              <v-card-actions class="d-flex justify-content-around">
                <v-btn class="btn-gold" text @click="deleteItemConfirm"
                  >Excluir</v-btn
                >
                <v-btn class="btn-gold" text @click="closeDelete"
                  >Cancelar</v-btn
                >
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-toolbar>
      </template>
      <template v-slot:item.actions="{ item }">
        <v-icon small class="mr-2" @click="editItem(item)">mdi-pencil</v-icon>
        <v-icon small @click="deleteItem(item)">mdi-delete</v-icon>
      </template>
      <template v-slot:no-data>
        <div>Nenhum item cadastrado até o momento</div>
      </template>
    </v-data-table>
  </div>
</template>
<script>
import DefaultService from "../../services/defaultService";

export default {
  async created() {
    this.defaultService = new DefaultService(this.$http, "tools");
    this.setDesserts();
  },
  data() {
    return {
      dialogDelete: false,
      itemToBeDeleted: null,
      defaultService: null,
      tools: null,
      headers: [
        { text: "Nome", value: "name" },
        { text: "Ações", value: "actions" },
      ],
      desserts: [],
    };
  },
  methods: {
    closeDelete() {
      this.itemToBeDeleted = null;
      this.dialogDelete = false;
    },

    deleteItem(item) {
      this.dialogDelete = true;
      this.itemToBeDeleted = item;
    },

    deleteItemConfirm() {
      this.defaultService.delete(this.itemToBeDeleted);
      this.desserts = [];
      this.dialogDelete = false;
      this.setDesserts();
    },

    editItem(item) {
      this.$router.push({ path: `tools/${item.id}/edit` });
    },

    newItem() {
      this.$router.push({ path: `tools/create` });
    },

    async setDesserts() {
      var tools = await this.defaultService.getAll();
      this.tools = tools.data;
      for (let i = 0; i < this.tools.length; i++) {
        this.desserts.push({ ...this.tools[i] });
      }
    },
  },
};
</script>
<style >
</style>