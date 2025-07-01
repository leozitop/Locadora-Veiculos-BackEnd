import React, { useEffect, useState } from 'react';
import api from '../services/api';

function ListaVeiculos() {
  const [veiculos, setVeiculos] = useState([]);

  useEffect(() => {
    api.get('/veiculos')
      .then(response => setVeiculos(response.data))
      .catch(error => console.error('Erro ao buscar veículos:', error));
  }, []);

  return (
    <div>
      <h2>Veículos</h2>
      <ul>
        {veiculos.map(v => (
          <li key={v.id}>{v.modelo} - {v.marca}</li>
        ))}
      </ul>
    </div>
  );
}

export default ListaVeiculos;