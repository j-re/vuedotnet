export const addProductToCart = ({
    state,
    commit
}, product) => {
    const index = state.cart.findIndex(
        i =>
            i.productId === product.productId &&
            i.colourId === product.colourId &&
            i.storageId === product.storageId
    );
    if (index >= 0) {
        commit("updateProductQuantity", index);
    } else {
        commit("addProductToCart", product);
    }
};

export const removeProductFromCart = ({ state, commit }, product) => {
    const index = state.cart.findIndex(
        i => i.productId === product.productId &&
            i.colourId === product.colourId &&
            i.storageId === product.storageId
    );

    commit("removeProductFromCart", index);
};

export const setProductQuantity = ({ state, commit }, payload) => {
    const index = state.cart.findIndex(
        i => i.productId === payload.product.productId &&
            i.colourId === payload.product.colourId &&
            i.storageId === payload.product.storageId
    );

    if (payload.quantity > 0) {
        commit("setProductQuantity", { index: index, quantity: payload.quantity });
    } else {
        commit("removeProductFromCart", index);
    }


};