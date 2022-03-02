export default class DefaultService{
    constructor($http, $rota){
        this.$http = $http
        this.$rota = $rota
    }
    async post(payload){
        return this.$http.post(`${this.$rota}`, {...payload})
    }
    async getAll(){
        return this.$http.get(`${this.$rota}`)
    }
    async getCount(){
        return this.$http.get(`${this.$rota}/count`)
    }
    async getById(id){
        
        return this.$http.get(`${this.$rota}/${id}`)
    }
    async delete(payload){
        return this.$http.delete(`${this.$rota}/${payload.id}`)
    }
    async put(payload){
        return this.$http.put(`${this.$rota}/${payload.id}`, {...payload})
    }
}