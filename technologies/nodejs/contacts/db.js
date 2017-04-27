const pg = require('pg');

const host = process.env['Contacts_DatabaseHost'];
const database = process.env['Contacts_DatabaseName'];
const username = process.env['Contacts_DatabaseUsername'];
const password = process.env['Contacts_DatabasePassword'];

const config = {
    host: host,
    database: database,
    user: username,
    password: password,
    max: 300,
};

const pool = new pg.Pool(config);

exports.query = (text, values, callback) => {
    return pool.query(text, values, callback);
};
