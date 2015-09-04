var AppDispatcher = require('../dispatcher/AppDispatcher');
var DevStoreConstants = require('../constants/DevStoreConstants');
var EventEmitter = require('events').EventEmitter;
var config = require('../../config');
var _ = require('underscore');

var urlApi = config.apiurl + "/cart/";

var _cart;

var CartStore = _.extend({}, EventEmitter.prototype, {


    Get: function () {
        return _cart;
    },
    AddItem: function (Item) {
        return _cart;
    },
    RemoveItem: function (Item) {
        return _cart;
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
        case DevStoreConstants.CART_LIST:
            Get(action.data);
            break;
        case DevStoreConstants.CART_REMOVE:
            RemoveItem(action.data);
            break;
        case DevStoreConstants.CART_ADD:
            AddItem(action.data);
            break;

        default:
            return true;
    }

    // If action was responded to, emit change event
    CartStore.emitChange();
    return true;

});
module.exports = CartStore;

