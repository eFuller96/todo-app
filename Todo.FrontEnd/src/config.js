const dev = {
    // Port is 5000, configured inside my launchSettings.json file
    endpoint: 'http://localhost:5000'
}

// The port is 90 because the container which hosts the web-api is being exposed via port 90 on my machine
// request will be sent on localhost:90 which will automatically map to localhost:5000 inside of the container
const prod = {
    endpoint: 'http://localhost:90'
}

const isDevelopment = () => {
    // this is ideally where I want to get to but at the moment running a container thinks it's dev mode still
    // return process.env.NODE_ENV === 'development'
    return false
}

const config = isDevelopment() ? dev : prod

if (isDevelopment()) {
    console.log(config)
}

export default config
