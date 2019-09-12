export const shoppingCartTotal = state => {
    const reducer = (accumulator, cartItem) =>
        accumulator + cartItem.price * cartItem.quantity;
    return state.cart.reduce(reducer, 0);
};

export const shoppingCartItemCount = state => {
    const reducer = (accumulator, cartItem) => accumulator +
        cartItem.quantity;
    return state.cart.reduce(reducer, 0);
};

export const isAuthenticated = state => {
    return (
        state.auth !== null &&
        state.auth.access_token !== null
    );
};

/*same as:
 * export const isAuthenticated = function(state,getters){
 *  return (
        state.auth !== null &&
        state.auth.access_token !== null &&
            new Date(state.auth.access_token_expiration) > new Date()
    );
 * }
 * Can then be called as store.getters.isAuthenticated;
 */


export const isInRole = (state, getters) => role => {
    const result = getters.isAuthenticated && state.auth.roles && state.auth.roles.indexOf(role) > -1;
    return result;
};
/*same as:
 * export const isInRole = function(state,getters){
 *  return function(role){
 *  const result = getters.isAuthenticated && state.auth.roles.indexOf(role) > -1;
    return result;
 *  }
 * }
 * 
 * Can then be called as store.getters.IsInRole("rolwa");
 * 
 */