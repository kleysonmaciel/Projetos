import React, {useEffect, useState} from 'react';
import axios from 'axios';

function ClienteList(){
    const [clientes, setClientes] = useState([]);
    useEffect(()=>{
        axios.get('/api/cliente')
        .then(response => {
            setClientes(response.data);
        });
    },[]);
    const deleteCliente = (id)=> {
        axios.delete(`/api/cliente/${id}`)
        .then(() =>{
            setClientes(clientes.filter(cliente => cliente.id !== id));
        });
    };
    return(
      <div>
        <h2>Lista de Clientes</h2>
        <ul>
            {clientes.map(cliente => (
                <li key={cliente.id}>
                    {cliente.nome}{cliente.sobrenome} - {cliente.email}
                    <buttoen onClick={()=> deleteCliente(cliente.id)}>Excluir</buttoen>
                </li>
            ))}
        </ul>
      </div>
    );
}
export default ClienteList;