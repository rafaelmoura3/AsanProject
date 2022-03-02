<template >
  <div>
    <div class="d-flex justify-content-center titulo">Lista de Naves</div>
    <v-data-table
      :headers="headers"
      :items="desserts"
      :footer-props="{
        'items-per-page-text': 'Naves por página:',
        pageText: '{0}-{1} de {2}',
      }"
      sort-by="calories"
      class="elevation-1"
    >
      <template v-slot:top>
        <v-toolbar flat>
          <v-spacer></v-spacer>
          <v-btn class="mb-2 btn-gold" @click="newItem"
            >Criar uma nova nave</v-btn
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
      <template v-slot:item.color="{ item }">
        <div
          class="d-flex justify-center border-color"
          :style="{ color: item.color, backgroundColor: item.color }"
        >
          {{ item.color }}
        </div>
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
import DefaultService from "../../services/defaultService"
export default {

    async created() {
        this.defaultService = new DefaultService(this.$http, 'ships')
        this.setDesserts()
    },
    data() {
        return {
            dialogDelete: false,
            itemToBeDeleted: null,
            defaultService: null,
            spaceShips: null,
            headers: [
                { text: 'Nome', value: 'name' },
                { text: 'Cor', value: 'color' },
                { text: 'Ano', value: 'year' },
                { text: 'Vida', value: 'health' },
                { text: 'Tipo', value: 'spaceShipType.name' },
                { text: 'Descrição', value: 'description' },
                { text: 'Ações', value: 'actions' },
            ],
            desserts: [
            ]
        }
    },
    methods: {

        closeDelete() {
            this.itemToBeDeleted = null
            this.dialogDelete = false
        },

        deleteItem(item) {
            this.dialogDelete = true
            this.itemToBeDeleted = item
        },

        deleteItemConfirm() {
            this.defaultService.delete(this.itemToBeDeleted)
            this.desserts = []
            this.dialogDelete = false
            this.setDesserts()
        },

        editItem(item) {
            this.$router.push({ path: `ships/${item.id}/edit` })
        },

        newItem() {
            this.$router.push({ path: `ships/create` })
        },

        async setDesserts() {
            var space_ships = await this.defaultService.getAll()
            this.spaceShips = space_ships.data
            for (let i = 0; i < this.spaceShips.length; i++) {
                this.desserts.push({ ...this.spaceShips[i] })
            }
        },
    }
}
</script>
<style lang="scss" scoped>
@import "../../assets/scss/index.scss";
</style>