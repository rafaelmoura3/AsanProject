       <template>
    <div class="text-center">
        <v-dialog v-model="dialogOptions.dialog"  width="500">
            <v-card >
                <v-card-title
                    :class="{ 'teal darken-2': dialogOptions.type === 'success', 'error darken-4': dialogOptions.type === 'error' }"
                >{{ dialogOptions.title }}</v-card-title>

                <v-card-text
                    class="d-flex justify-center my-4 mt-10"
                >{{ dialogOptions.message }}</v-card-text>
                <v-divider></v-divider>
                    <div class="d-flex justify-center ">
                        <v-btn
                            class="btn-gold mb-6"
                            text
                            @click="abreModal"
                        >{{ dialogOptions.botaoText }}</v-btn>
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
                    title: "Pronto!",
                    dialog: true,
                    message: {
                        type: String,
                        default: "Obrigatório"
                    },
                    type: "error",
                    botaoText: "Entendido"
                }
            }
        }
    },
    watch: {
        'dialogOptions.dialog': function () {
            if (this.dialogOptions.dialog == false) {
                this.$emit('dialog_false')
            }
        },
    },
    methods: {
        abreModal() {
            this.$emit('dialog_false')
        }
    }
}
</script>

<style  lang="scss" scoped>
@import "../assets/scss/index.scss";
