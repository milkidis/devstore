var AppDispatcher = require('../dispatcher/AppDispatcher');
var DevStoreConstants = require('../constants/DevStoreConstants');

var FluxDevActions = {


    listDevs: function (payload) {
        AppDispatcher.dispach(DevStoreConstants.DEV_LIST, payload);
    },




}
module.exports = FluxDevActions;