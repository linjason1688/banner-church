const rootConfig = Object.assign({ env: process.env.NODE_ENV.toLocaleLowerCase() }, require("./app.config.json"));

// dynamic load env config
const envConfig = require(`./app.config-${rootConfig.env}.json`);
const config = Object.assign(rootConfig, envConfig);

if ("$.hash" === config.version)
{
  try
  {
    config.version = require("child_process").execSync("git rev-parse --short HEAD").toString().trim();
  } catch (error)
  {
    if (!config.version)
    {
      config.version = new Date().toJSON();
      console.log("NOT a git repository, using date instead");
    } else
    {
      config.version = config.version.substring(0, 5);
    }
  }
}

console.log(config, "\n");

module.exports = config;
