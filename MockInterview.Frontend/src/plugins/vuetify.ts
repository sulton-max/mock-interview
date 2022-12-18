import Vue from 'vue';
import Vuetify from 'vuetify/lib/framework';
import '@fortawesome/fontawesome-free/css/all.css'

Vue.use(Vuetify);

export default new Vuetify({
    theme: {
        options: {
            customProperties: true,
        },
        themes: {
            light: {
                lightBlue: '#F5F8FF'
            },
        },
    },
    icons: {
        iconfont: 'fa' || 'mdi' || 'mdiSvg' || 'md',
    },
});
