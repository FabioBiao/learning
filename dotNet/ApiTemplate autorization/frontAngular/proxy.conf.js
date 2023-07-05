const PROXY_CONFIG = [
  {
    context: ["/api"],
    target: "https://localhost:44388",
    secure: false,
    logLevel: "error",
    changeOrigin: true,
  },
];
module.exports = PROXY_CONFIG;
