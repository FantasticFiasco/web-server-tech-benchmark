const restify = require('restify');
const health = require('./health/controller');
const echo = require('./echo/controller');
const relay = require('./relay/controller');
const contacts = require('./contacts/controller');

const server = restify.createServer();

// Middleware
server.use(restify.bodyParser());

// Health
server.get('/health', health.get);

// Echo
server.get('/echo/:text', echo.get);

// Relay
server.get('/relay/:key', relay.get);

// Contects
server.post('/contacts', contacts.create);
server.get('/contacts/:id', contacts.get);
server.get('/contacts', contacts.getAll);
server.del('/contacts/:id', contacts.delete);

server.listen(8090, () => {
  console.log('%s listening at %s', server.name, server.url);
});
