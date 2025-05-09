import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
   server: {
    port: 3000,
    strictPort: true,
   },
   build: {
     rollupOptions: {
       output: {
         manualChunks: {
           // Split large libraries into separate chunks
           react: ["react", "react-dom"],
           mui: ["@mui/material", "@emotion/react", "@emotion/styled", "@mui/icons-material"],
           bootstrap: ["react-bootstrap", "bootstrap"],
           mobx: ["mobx", "mobx-react-lite"],
           vendor: ["axios", "react-query", "react-router-dom"]
         },
       },
     },
   },
 });