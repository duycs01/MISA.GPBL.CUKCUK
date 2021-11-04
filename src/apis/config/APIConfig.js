
/**
 * config url api
 */
var APIConfig = {
    development: 'https://localhost:44315/api/'
}
export default APIConfig[process.env.NODE_ENV]
