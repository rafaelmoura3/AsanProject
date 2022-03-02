<template>
  <div>
    <div class="d-flex justify-content-center titulo">Lista de Problemas</div>
    <v-data-table
      :headers="headers"
      :items="desserts"
      :footer-props="{
        'items-per-page-text': 'Problemas por página:',
        pageText: '{0}-{1} de {2}',
      }"
      sort-by="calories"
      class="elevation-1"
    >
      <template v-slot:top>
        <v-toolbar flat>
          <v-divider class="mx-4" inset vertical></v-divider>
          <v-spacer></v-spacer>
          <v-btn class="mb-2 btn-gold" @click="newItem"
            >Criar um novo problema</v-btn
          >
          <!--criar um método newItem para abrir um modal com o componente de edição padrão -->
          <v-dialog v-model="dialog" max-width="500px">
            <v-card>
              <v-card-title>
                <span class="text-h5">{{ formTitle }}</span>
              </v-card-title>

              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12" sm="6" md="4">
                      <v-text-field
                        v-model="ItemToBeEdited.name"
                        label="Nome"
                      ></v-text-field>
                    </v-col>
                  </v-row>
                </v-container>
              </v-card-text>

              <v-card-actions class="justify-content-around">
                <v-btn class="btn-gold" text @click="close">Cancelar</v-btn>
                <v-btn class="btn-gold" text @click="save">Salvar</v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
          <v-dialog v-model="dialogDelete" max-width="500px">
            <v-card>
              <v-card-title class="body-style d-flex justify-center"
                >Deseja excluir este item?</v-card-title
              >
              <v-card-actions class="d-flex justify-content-around">
                <v-btn class="btn-gold" @click="deleteItemConfirm"
                  >Excluir</v-btn
                >
                <v-btn class="btn-gold" @click="closeDelete">Cancelar</v-btn>
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
  data: () => ({
    dialog: false,
    dialogDelete: false,
    headers: [
      {
        text: "Nome",
        align: "start",
        sortable: false,
        value: "name",
      },

      { text: "Ações", value: "actions", sortable: false },
    ],
    problemsData: {},
    desserts: [],
    editedIndex: -1,
    editedItem: {
      name: "",
    },
    problems: null,
    defaultItem: {
      name: "",
    },
    ItemToBeEdited: {},
    defaultService: null,
    itemToDelete: null,
    method: null,
  }),

  async created() {
    this.defaultService = new DefaultService(this.$http, "problems");

    this.ListarProblems();
  },

  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Novo problema" : "Editar problema";
    },
  },

  watch: {
    dialog(val) {
      val || this.close();
    },
    dialogDelete(val) {
      val || this.closeDelete();
    },
  },

  methods: {
    
    close() {
      this.dialog = false;
    },

    closeDelete() {
      this.dialogDelete = false;
    },

    deleteItem(item) {
      this.itemToDelete = item;
      this.dialogDelete = true;
    },

    async deleteItemConfirm() {
      var delete_problems = await this.defaultService.delete(this.itemToDelete);
      this.dialogDelete = false;
      this.ListarProblems();
      return delete_problems;
    },

    editItem(item) {
      this.$router.push({
        path: `problems/${item.id}/edit`,
      });
    },

    async ListarProblems() {
      this.desserts = [];
      this.problems = await this.defaultService.getAll();
      for (let index = 0; index < this.problems.data.length; index++) {
        this.desserts.push({ ...this.problems.data[index] });
      }
    },

    newItem() {
      this.$router.push({ path: `problems/create` });
    },

    async save() {
      if (this.method == "create") {
        var create_problems = await this.defaultService.post(
          this.ItemToBeEdited
        );
        this.dialog = false;
        return create_problems;
      } else {
        var edit_problems = await this.defaultService.put(this.ItemToBeEdited);
        this.dialog = false;
        return edit_problems;
      }
    },
  },
};
</script>
<style  lang="scss" scoped>
@import "../../assets/scss/index.scss";
</style>