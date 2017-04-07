const request = require('request');

const hostname = process.env['Relay:KeyValueServiceHostname'];
const port = process.env['Relay:KeyValueServicePort'];

exports.get = (req, res, next) => {
    return request(`http://${hostname}:${port}/store/${req.params.key}`, (error, response, body) => {
        next.ifError(error);

        res.send(JSON.parse(body));
        next();
    });
};
