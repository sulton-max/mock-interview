import axios,{AxiosInstance} from "axios";

export default class ServiceBase {
    private client!: AxiosInstance;

    protected getClient(): AxiosInstance{
        if (this.client == null) {
            this.client = axios.create({
                baseURL: "/api"
            })
        }
        return this.client;
    }
}