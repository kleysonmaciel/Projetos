import React, {useState, useEffect} from 'react';
import axios from 'axios';

function ClienteEdit({id}){
    const [cliente, setCliente] = useState({
        id:'',
        nome: '',
        sobrenome: '',
        email: '',
        cpf: '',
        endereco: '',
        cep:''
    });

    const [loading, setLoading] = useState(true);

    const [error, setError] = useState(null);

    useEffect(()=>{
        axios.get(`/api/cliente/${id}`)
        .then(Response => {
            setCliente(response.data);
            setLoading(false);
        })
        .catch(err =>{
            setError('Erro ao buscar os dados do cliente.');
            setLoading(false)
        });
    },[id]);
    const handleChange = (e) => {
        setCliente({
            ...cliente,
            [e.target.name]: e.target.value
        });
    };
    const handleSubmit = (e)=>{
        e.preventDefault();
        axios.put(`/api/cliente/${id}`, cliente)
        .then(()=>{
            alert('Cliente atualizado com sucesso!');
        })
        .catch(err => {
            setError('Erro ao atualizar cliente.');
        });
    };
    if (loading) return <p>Carregando...</p>;
    if (error) return <p>{error}</p>;
    return(
        <form onSubmit={handleSubmit}>
      <h2>Editar Cliente</h2>
      <input
        name="nome"
        value={cliente.nome}
        onChange={handleChange}
        placeholder="Nome"
        required
      />
      <input
        name="sobrenome"
        value={cliente.sobrenome}
        onChange={handleChange}
        placeholder="Sobrenome"
        required
      />
      <input
        name="email"
        type="email"
        value={cliente.email}
        onChange={handleChange}
        placeholder="Email"
        required
      />
      <input
        name="cpf"
        value={cliente.cpf}
        onChange={handleChange}
        placeholder="CPF"
        required
      />
      <input
        name="endereco"
        value={cliente.endereco}
        onChange={handleChange}
        placeholder="Endereço"
      />
      <input
        name="cep"
        value={cliente.cep}
        onChange={handleChange}
        placeholder="CEP"
      />
      <button type="submit">Atualizar</button>
    </form>
  );
}
export default ClienteEdit;