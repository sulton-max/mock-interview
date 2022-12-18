const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: [
    'vuetify'
  ],
  devServer: {
    proxy: {
      "^/api": {
        target: "https://66d8-89-236-218-41.in.ngrok.io",
        changeOrigin: true,
        secure: false,
        logLevel: "debug",
        pathRewrite: { "^/api": "/api" },
      },
    },
  },
})