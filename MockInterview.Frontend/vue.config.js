const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: [
    'vuetify'
  ],
  devServer: {
    proxy: {
      "^/api": {
        target: "https://localhost:7222",
        changeOrigin: true,
        secure: false,
        logLevel: "debug",
        pathRewrite: { "^/api": "/api" },
      },
    },
  },
})