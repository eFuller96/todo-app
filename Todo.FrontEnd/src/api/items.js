const get = async (uri) => {
    return await fetch(uri, {
        method: 'GET',
        headers: {
            'Access-Control-Allow-Origin': '*'
        }
    })
}

const baseUrl = 'https://localhost:5001'

export async function getItems() {
    return await get(`${baseUrl}/item`)
}
