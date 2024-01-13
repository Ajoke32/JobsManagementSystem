import { createLogger, defineConfig } from 'vite'
import react from '@vitejs/plugin-react'



export default defineConfig({
  plugins: [react()],
  
  build:{
    outDir:'build'
  },
  
  server:{
    https:false,
    hmr:{
      host:'localhost',
      port:3001,
      protocol:'ws',
    }
  }
});
