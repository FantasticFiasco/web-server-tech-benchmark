const db = require('./db');

exports.create = (req, res, next) => {
    return db.query(
        'INSERT INTO contact (firstName, surname) VALUES ($1, $2) RETURNING id',
        [req.body.firstName, req.body.surname],
        (error, result) => {
            next.ifError(error);

            const contact = {
                id: result.rows[0].id,
                firstName: req.body.firstName,
                surname: req.body.surname
            };

            res.header('Location', `http://${req.headers.host}/contacts/${contact.id}`);
            res.json(201, contact);
            next();
        }
    );
};

exports.get = (req, res, next) => {
    return db.query(
        'SELECT * FROM contact WHERE Id = $1',
        [req.params.id],
        (error, result) => {
            next.ifError(error);

            res.json(mapToContact(result.rows[0]));
            next();
        }
    );
};

exports.getAll = (req, res, next) => {
    return db.query(
        'SELECT * FROM contact',
        [],
        (error, result) => {
            next.ifError(error);

            const contacts = result.rows.map((row) => {
                return mapToContact(row);
            });

            res.json(contacts);
            next();
        }
    );
};

exports.delete = (req, res, next) => {
    return db.query(
        'DELETE FROM contact WHERE Id = $1',
        [req.params.id],
        (error, result) => {
            next.ifError(error);

            res.send(204);
            next();
        }
    );
};

const mapToContact = (row) => {
    return {
        id: row.id,
        firstName: row.firstname,
        surname: row.surname,
    };
};
