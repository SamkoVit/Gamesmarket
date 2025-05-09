import axios from "axios";

export const API_URL = `https://products-api1-cue8a2evdrgphfa6.germanywestcentral-01.azurewebsites.net/api`;
export const API_URL_IMG = `https://products-api1-cue8a2evdrgphfa6.germanywestcentral-01.azurewebsites.net/`;

const $api = axios.create({
  withCredentials: true,
  baseURL: API_URL,
});

$api.interceptors.request.use((config) => {
  config.headers.Authorization = `Bearer ${localStorage.getItem("token")}`;
  return config;
});

export default $api;
