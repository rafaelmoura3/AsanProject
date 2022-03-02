
<template>
    <div class="text-center body-text">
        <v-dialog v-model="dialogDelete.dialog" max-width="500px">
            <v-card>
                <v-card-title class="body-style d-flex justify-center">Deseja excluir este item?</v-card-title>
                <v-card-actions class="d-flex justify-content-around">
                    <v-btn
                        class="btn-gold"
                        :loading="deleteLoading"
                        @click="deleteItemConfirm"
                    >Excluir</v-btn>
                    <v-btn class="btn-gold" @click="closeDelete">Cancelar</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
</template>
<script>
export default {
    data() {
        return {
            
        }
    },
    props: {
        dialogDelete: {
            default: function () {
                return {
                    dialog: true,

                }
            }
        },
        deleteLoading: {
            type: Boolean,
            default: false
        }
    },
    watch: {
        'dialogDelete.dialog': function () {
            if (this.dialogDelete.dialog == false) {
                this.$emit('false_dialog')
            }
        },
    },
    methods: {
        closeDelete() {
            this.$emit('false_dialog')
        },
        deleteItemConfirm() {
            this.$emit('delete_confirm')
        }
    }
}
</script>
<style  lang="scss" scoped>
@import "../assets/scss/index.scss";
</style>