var path = require("path");
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');

module.exports = {
  entry: "./src/main.js",
  // optimization: {
  //   minimize: false
  // },
  output: {
    filename: "mdcjs.js",
    // path: path.resolve(__dirname, '../dist'),
    path: path.resolve(__dirname, '../../content/dist'),
  },

  module: {
    rules: [
      {
        test: /\.js$/,
        use: {
          loader: "babel-loader",
          options: {

          }
        }
      },
      {
        test: /\.scss$/,
        use: [
          {
            loader: "style-loader" // creates style nodes from JS strings
          },
          {
            loader: "css-loader" // translates CSS into CommonJS
          },
          {
            loader: "sass-loader", // compiles Sass to CSS
            options: {
              "includePaths": [
                path.resolve(__dirname, '../node_modules')
              ]
            }
          }
        ]
      }
    ]
  },

  plugins: [
      new UglifyJsPlugin({
          parallel: true,
          uglifyOptions: {
              compress: {},
              mangle: true,
              output: {
                  comments: false,
                  beautify: false
              }
          }
    }),
  ],
};
