var AppDispatcher = require('js/dispatcher/AppDispatcher');
var DevStoreConstants = require('../constants/DevStoreConstants');

var FluxCartActions = {


    listItens: function (payload) {
        AppDispatcher.dispach(DevStoreConstants.CART_LIST, payload);
    },

    addItem: function (payload) {
        AppDispatcher.dispach(DevStoreConstants.CART_ADD, payload);
    },
    removeItem: function (payload) {
        AppDispatcher.dispach(DevStoreConstants.CART_REMOVE, payload);
    }




}
module.exports = FluxCartActions;