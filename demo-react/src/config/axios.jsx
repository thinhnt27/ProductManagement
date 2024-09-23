import axios from 'axios';

const api = axios.create({
  baseURL: 'http://128.199.177.223:8888/api/',
});

export default api;
