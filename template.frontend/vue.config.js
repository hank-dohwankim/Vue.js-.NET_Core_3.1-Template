"use strict";

module.exports = {
  outputDir: "../build",
  productionSourceMap: false,
  devServer: {
    proxy: {
      // '/api': {
      //   target: 'https://localhost:44371/api',
      //   changeOrigin: true,
      //   pathRewrite: {
      //     '^/api': ''
      //   }
      // },
      // '/auth': {
      //   target: 'http://localhost:3000/auth',
      //   changeOrigin: true,
      //   pathRewrite: {
      //     '^/auth': ''
      //   }
      // },
      // '/api/admin': {
      //   target: 'http://localhost:3000/api/admin',
      //   changeOrigin: true,
      //   pathRewrite: {
      //     '^/api/admin': ''
      //   }
      // },
    }
  }
};
