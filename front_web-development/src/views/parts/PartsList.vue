<template >
  <div>
    <div class="d-flex justify-content-center titulo">Lista de Peças</div>
    <v-data-table
      :headers="headers"
      :items="desserts"
      :footer-props="{
        'items-per-page-text': 'Peças por página:',
        pageText: '{0}-{1} de {2}',
      }"
      sort-by="calories"
      class="elevation-1"
    >
      <template v-slot:top>
        <v-toolbar flat>
          <v-spacer></v-spacer>
          <v-btn class="mb-2 btn-gold" @click="newItem"
            >Criar uma nova peça</v-btn
          >
          <!--criar um método newItem para abrir um modal com o componente de edição padrão -->
          <v-dialog v-model="dialogDelete" max-width="500px">
            <v-card>
              <v-card-title class="body-style d-flex justify-center"
                >Deseja excluir este item?</v-card-title
              >
              <v-card-actions class="d-flex justify-content-around">
                <v-btn class="btn-gold" @click="deleteItemConfirm()"
                  >Excluir</v-btn
                >
                <v-btn class="btn-gold" @click="closeDelete()">Cancelar</v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-toolbar>
      </template>
      <template v-slot:item.actions="{ item }">
        <div class="actions-inline">
          <v-icon small class="mr-2" @click="editItem(item)">mdi-pencil</v-icon>
          <v-icon small @click="deleteItem(item)">mdi-delete</v-icon>
        </div>
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
    this.defaultService = new DefaultService(this.$http, "parts");
    this.setDessertsWhenCreated();
  },

  data() {
    return {
      Parts: [],
      dialog: false,
      dialogDelete: false,
      formTitle: "",
      headers: [
        { text: "Nome", value: "name" },
        { text: "Vida", value: "health" },
        { text: "Descrição", value: "description" },
        {
          text: "Ações",
          value: "actions",
          sortable: false,
        },
      ],
      desserts: [],
      ItemToBeEdited: {},
      itemToDelete: null,
      method: null,
      defaultService: null,
    };
  },
  methods: {

    close() {
      this.dialog = false;
    },

    closeDelete() {
      this.dialogDelete = false;
    },

    create() {
      this.methodBtnSalvar = "Cadastrar";
      this.method = "create";
    },

    deleteItem(item) {
      this.itemToDelete = item;
      this.dialogDelete = true;
    },

    async deleteItemConfirm() {
      console.log(this.itemToDelete);

      var delete_parts = await this.defaultService.delete(this.itemToDelete);
      this.dialogDelete = false;
      this.desserts = [];
      this.setDessertsWhenCreated();
      return delete_parts;
    },

    editedItem(item) {
      console.log(item);
    },

    async editItem(item) {
      this.methodBtnSalvar = "Salvar";
      this.ItemToBeEdited = item;
      this.$router.push(`parts/${item.id}/edit`);
    },

    initialize() {},

    newItem() {
      this.$router.push({ path: `parts/create` });
    },

    async save() {
      if (this.method == "create") {
        var create_space_ship = await this.defaultService.post(
          this.ItemToBeEdited
        );
        this.dialog = false;
        return create_space_ship;
      } else {
        var edit_space_ship = await this.defaultService.put(
          this.ItemToBeEdited
        );
        this.dialog = false;
        return edit_space_ship;
      }
    },

    async setDessertsWhenCreated() {
      this.Parts = await this.defaultService.getAll();
      console.log(this.Parts);
      for (let i = 0; i < this.Parts.data.length; i++) {
        this.desserts.push({
          id: this.Parts.data[i].id,
          name: this.Parts.data[i].name,
          health: this.Parts.data[i].health,
          description: this.Parts.data[i].description,
        });
      }
    },
  },
};
</script>
<style  lang="scss" scoped>
@import "../../assets/scss/index.scss";
</style>

