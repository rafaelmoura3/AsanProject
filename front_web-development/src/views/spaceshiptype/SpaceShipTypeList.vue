<template >
  <div>
    <div class="d-flex justify-content-center titulo">
      Lista de Tipos de Naves
    </div>
    <v-data-table
      :headers="headers"
      :items="desserts"
      :footer-props="{
        'items-per-page-text': 'Tipos de Naves por página:',
        pageText: '{0}-{1} de {2}',
      }"
      sort-by="calories"
      class="elevation-1"
    >
      <template v-slot:top>
        <v-toolbar flat>
          <v-divider class="mx-4" inset vertical></v-divider>
          <v-spacer></v-spacer>
          <v-dialog v-model="dialog" max-width="500px">
            <template v-slot:activator="{ on, attrs }">
              <v-btn
                primary
                dark
                class="mb-2 btn-gold"
                v-bind="attrs"
                v-on="on"
                @click="create"
                >Criar um novo tipo de nave</v-btn
              >
            </template>
            <v-card>
              <v-card-title>
                <span class="text-h5">Criando um novo tipo de nave</span>
              </v-card-title>
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12" sm="6" md="4">
                      <v-text-field
                        v-model="ItemToBeEdited.Name"
                        label="Nome"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12" sm="6" md="4">
                      <v-text-field
                        v-model="ItemToBeEdited.Description"
                        label="Descrição"
                        auto-grow
                      ></v-text-field>
                    </v-col>
                  </v-row>
                </v-container>
              </v-card-text>

              <v-card-actions class="d-flex justify-content-around">
                <v-card-title class="body-style d-flex justify-center"
                  >Deseja excluir este item?</v-card-title
                >
                <v-btn class="btn-gold" @click="close">Cancelar</v-btn>
                <v-btn class="btn-gold" @click="save">{{
                  methodBtnSalvar
                }}</v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
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
      <template v-slot:header.name="{ header }" class="min-width-actions">
        <div>{{ header.text }}</div>
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
import DefaultService from "../../services/defaultService.js";
export default {
  async created() {
    this.defaultService = new DefaultService(this.$http, "spaceshiptype");
    this.setDessertsWhenCreated();
  },
    data() {
        return {
            SpaceShipType: [],
            defaultService: null,
            dialog: false,
            dialogDelete: false,
            formTitle: "",
            count: {},
            headers: [
                { text: 'Nome', value: 'name' },
                { text: 'Descrição', value: 'description' },
                {
                    text: "Ações",
                    value: "actions",
                    sortable: false,
                },
            ],
            desserts: [
            ],
            ItemToBeEdited: {
            },
            itemToDelete: null,
            method: null,
            methodBtnSalvar: null
        }
    },
    methods: {
        create() {
            this.$router.push({
                path: 'spaceshiptype/create'
            })
        },
        close() {
            this.dialog = false
        },
        async save() {
           
            if (this.method == 'create') {
                var create_space_ship = await this.defaultService.post(this.ItemToBeEdited);
                this.dialog = false
                this.desserts = []
                this.setDessertsWhenCreated();
                return create_space_ship
            }
            else {
                var edit_space_ship = await this.defaultService.put(this.ItemToBeEdited);
                this.dialog = false
                return edit_space_ship
            }

        },
        closeDelete() {
            this.dialogDelete = false
        },
        async deleteItemConfirm() {
            var delete_space_ship = await this.defaultService.delete(this.itemToDelete);
            this.dialogDelete = false
            this.desserts = []
            this.setDessertsWhenCreated();
            return delete_space_ship
        },
        editItem(item) {
            this.$router.push({ path: `spaceshiptype/${item.id}/edit` })
        },
        deleteItem(item) {
            this.itemToDelete = item
            this.dialogDelete = true
        },
        editedItem() {
        },
        initialize() {

        },
        async setDessertsWhenCreated() {
            this.SpaceShipType = await this.defaultService.getAll()
            console.log(this.SpaceShipType);
            for (let i = 0; i < this.SpaceShipType.data.length; i++) {
                this.desserts.push({ ...this.SpaceShipType.data[i] })
            }
        }

        // async getCountSpaceShipType(item) {
        //     this.count = await this.defaultService.getCount()   
        //     for (let i = 0; i < this.count.data.length; i++) {    
        //         // if (a == this.SpaceShipType.data[i].id) {
        //             item = this.count.data[i].countSpaceShip    
        //         // } 
                
        //         console.log(item);
        //     }  
            
        // }

    },
}
</script>
<style  lang="scss" >
@import "../../assets/scss/index.scss";
</style>

