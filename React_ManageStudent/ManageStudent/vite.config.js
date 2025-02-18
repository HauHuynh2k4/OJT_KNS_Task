import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import "core-js/actual/structured-clone";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    proxy: {
      "/api": {
        target: "https://localhost:44342", // Update this URL to match your .NET backend URL
        changeOrigin: true,
        secure: false,
      },
    },
  },
});
