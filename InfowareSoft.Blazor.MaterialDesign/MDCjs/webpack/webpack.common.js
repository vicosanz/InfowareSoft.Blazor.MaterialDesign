var path = require("path");
const TerserPlugin = require("terser-webpack-plugin");
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

module.exports = {
    entry: {
        'mdcjs': [
            "./src/main.js",
            "./src/main.scss",
        ]
    },
    output: {
        filename: "mdcjs.js",
        path: path.resolve(__dirname, '../../wwwroot/dist'),
    },

    optimization: {
        minimizer: [new TerserPlugin()],
    },

    module: {
        rules: [
            // ...Other rules,
            {
                test: /\.s[ac]ss$/i,
                use: [
                    MiniCssExtractPlugin.loader,
                    {
                        loader: "css-loader" // translates CSS into CommonJS
                    },
                    {
                        loader: "sass-loader", // compiles Sass to CSS
                        options: {
                            // Prefer Dart Sass
                            implementation: require('sass'),

                            webpackImporter: false, // Recommended temporary workaround until https://github.com/webpack-contrib/sass-loader/issues/804 is fixed
                            sassOptions: {
                                "includePaths": [
                                    path.resolve(__dirname, '../node_modules')
                                ]
                            },
                        }
                    }
                ]
            },
        ],
    },

    plugins: [
        new MiniCssExtractPlugin({
            filename: '../../wwwroot/dist/mdcjs.css',
        }),
    ],
};
