<template>
    <div class="sales">
        <h2>Vendas</h2>
        <table>
            <thead>
                <tr>
                    <th>Produto</th>
                    <th>Quantidade</th>
                    <th>Preço Total</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="sale in sale" :key="sale.id">
                    <td>{{ sale.produtonome }}</td>
                    <td>{{ sale.quantidade }}</td>
                    <td>{{ sale.total }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default{
    name: "Sales",
    data(){
        return{
            sales: []
        };
    },
    async created(){
        await this.fetchSales();
    },
    methods: {
        async fetchSales(){
            try{
                const response = await axios.get('/api/venda');
                this.sale = response.date;
            }catch (error){
                alert('Erro ao buscar vendas: ' + error.response.data.message);
            }
        }
    }
}
</script>

<style scoped>
.sales{
    padding: 20px;
}
.sales h2{
    margin-bottom: 20px;
}
.sales table{
    width: 100%;
    border-collapse: collapse;
}
.sales th, .sales td{
    border: 1px solid #ccc;
    padding: 10px;
    text-align: left;
}
</style>