import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:5001/api', // ou http://localhost:5000/api dependendo do seu projeto
});

export default api;