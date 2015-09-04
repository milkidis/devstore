var AppDispatcher = require('../dispatcher/AppDispatcher');
var DevStoreConstants = require('../constants/DevStoreConstants');
var EventEmitter = require('events').EventEmitter;
var config = require('../../config');
var _ = require('underscore');

var urlApi = config.apiurl + "/developer/";

var _developers;

function getPageDev(page) {
    var api = require('promise-ajax')(urlApi);
    api.get('GetPage', { page: 1 }).then(function (data) {
        _developers = data;
    }, function (data) {
        console.log(data);
    });
    return _developers;
}
var DevStore = _.extend({}, EventEmitter.prototype, {


    getPage: function (page) {
        getPageDev(page);
        return JSON.parse(_developers);
    },

    // Emit Change event
    emitChange: function () {
        this.emit('change');
    },

    // Add change listener
    addChangeListener: function (callback) {
        this.on('change', callback);
    },

    // Remove change listener
    removeChangeListener: function (callback) {
        this.removeListener('change', callback);
    }

});

// Register callback with AppDispatcher
AppDispatcher.register(function (payload) {
    var action = payload.action;
    var text;

    switch (action.actionType) {

        // Respond to RECEIVE_DATA action
        case DevStoreConstants.DEV_LIST:
            getPage(action.data);
            break;

        default:
            return true;
    }

    // If action was responded to, emit change event
    DevStore.emitChange();

    return true;

});
module.exports = DevStore;

