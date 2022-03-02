       <template>
    <div class="text-center">
        <v-dialog v-model="dialogOptions.dialog" width="500">
            <v-card>
                <div class="d-flex justify-center">
                    <v-card-title
                        class="text-h4"
                        :class="{ 'teal darken-2': dialogOptions.type === 'success', 'error darken-4': dialogOptions.type === 'error' }"
                    >{{ dialogOptions.title }}</v-card-title>
                </div>
                <v-card-text class="text-h6 d-flex justify-center">Id da Nave: {{ spaceShip.id }}</v-card-text>
                <v-card-text
                    class="text-h6 d-flex justify-center"
                >Nome da Nave: {{ spaceShip.name }}</v-card-text>
                <v-card-text
                    class="text-h6 d-flex justify-center"
                >Vida da Nave: {{ spaceShip.health }}</v-card-text>
                <v-card-text class="text-h6 d-flex justify-center">Ano da Nave: {{ spaceShip.year }}</v-card-text>
                <v-divider></v-divider>
                <div class="d-flex justify-content-around">
                    <v-btn class="btn-gold mb-6" text @click="cancelarManutencao">Cancelar</v-btn>
                    <v-btn class="btn-gold mb-6" text @click="efetuarManutencao">Efetuar Manutenção</v-btn>
                </div>
            </v-card>
        </v-dialog>
    </div>
</template>
<script>
export default {
    props: {
        dialogOptions: {
            default: function () {
                return {
                    title: "Dados da Nave",
                    dialog: true,
                    name: "teste",
                    message: {
                        type: String,
                        default: "Obrigatório"
                    },
                    type: "error",
                    botaoText: "Entendido"
                }
            }
        },
        spaceShip:
        {
            default: function () {
                return {
                    id: 0,
                    name: "",
                    health: 0,
                    year: 2000
                }
            }
        }
    },
    methods: {
        efetuarManutencao() {
            this.$emit('efetuarManutencao', this.spaceShip.id)
        },
        cancelarManutencao() {
            this.$emit('cancelarManutencao')
        }
    }
}
</script>

<style  lang="scss" scoped>
@import "../assets/scss/index.scss";
