const request = require('request');

const hostname = process.env['Relay_KeyValueServiceHostname'];
const port = process.env['Relay_KeyValueServicePort'];

exports.get = (req, res, next) => {
    return request(`http://${hostname}:${port}/store/${req.params.key}`, (error, response, body) => {
        next.ifError(error);

        const keyValue = JSON.parse(body);
        const keyValuePair = {
            key: req.params.key,
            value: keyValue.value,
        };

        res.json(keyValuePair);
        next();
    });
};
