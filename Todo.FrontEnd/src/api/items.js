import config from '../config.js'

const get = async (uri) => {
    return await fetch(uri, {
        method: 'GET',
        headers: {
            'Access-Control-Allow-Origin': '*'
        }
    })
}

const baseUrl = config.endpoint

export async function getItems() {
    return await get(`${baseUrl}/item`)
}
