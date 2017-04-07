exports.get = (req, res, next) => {
    res.header('Content-Type', 'text/plain');
    res.send(req.params.text);
    next();
};
