import React, {useState} from 'react';
import axios from 'axios';

function ClienteForm(){
    const [cliente, setCliente] = useState({
        nome: '',
        sobrenome: '',
        email: '',
        cpf: '',
        endereco: '',
        cep:''
    });
    const handleChange = (e) => {
        setCliente({
            ...cliente,
            [e.target.name]: e.target.value
        });
    };
    const handleSubmit = (e) => {
        e.preventDefault();
        axios.post('api/cliente', cliente)
        .then(()=>{
            setCliente({
                nome: '',
                sobrenome: '',
                email: '',
                cpf: '',
                endereco: '',
                cep:''
            });
        });
    };
    return(
        <form onSubmit={handleSubmit}>
            <input name="nome" value={cliente.nome} onChange={handleChange} placeholder="Nome" />
            <input name="sobrenome" value={cliente.sobrenome} onChange={handleChange} placeholder="Sobrenome" />
            <input name="email" value={cliente.email} onChange={handleChange} placeholder="Email" />
            <input name="cpf" value={cliente.cpf} onChange={handleChange} placeholder="CPF" />
            <input name="endereco" value={cliente.endereco} onChange={handleChange} placeholder="Endereço" />
            <input name="cep" value={cliente.cep} onChange={handleChange} placeholder="CEP" />
            <button type="submit">Cadastar</button>
        </form>
    );
}
export default ClienteForm;