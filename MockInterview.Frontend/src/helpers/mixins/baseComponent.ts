import { sweetAlertError } from "../../plugins/swal";
import Vue from 'vue';
import { Component } from "vue-property-decorator";

const LOADING = 0;
const LOADED = 1;
const FAILED = -1;

@Component
export default class BaseComponent extends Vue {
    public loading: null | number = null;
    public watchModal = false;

    public loadingStart() {
        this.loading = LOADING;
    }

    public loadingFail() {
        this.loading = FAILED;
    }

    public loadingFinish() {
        this.loading = LOADED;
    }

    public async startLoading(callback: Function) {
        try {
            this.loadingStart();
            await callback();
            this.loadingFinish();
        } catch (error) {
            this.loadingFail();
            // eslint-disable-next-line @typescript-eslint/ban-ts-comment
            // @ts-ignore
            sweetAlertError(error.message)
        }
    }

    public clearFormChanges(): void{
        this.watchModal = !this.watchModal;
    }

    get isLoading() {
        return this.loading === LOADING;
    }

    get isFailed() {
        return this.loading === FAILED;
    }

    get isLoaded() {
        return this.loading === LOADED;
    }
}