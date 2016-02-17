namespace DevStation.Controllers {
    export class DevSearchController {
        public devs;

        //public searchDevs(searchTerm: string) {
        //    this.devs = [];

        //    if (searchTerm != "") {
        //        this.$http.get(`/api/devs/search/${searchTerm}`)
        //            .then((response) => {
        //                this.devs = response.data;
        //            });
        //    }
        //    this.$http.get(`api/devs/list`)
        //        .then((response) => {
        //            this.devs = response.data;
        //        });
        //}


        public constructor(private $http: ng.IHttpService, private $location) {
            this.$http.get(`api/devs/list`)
                .then((response) => {
                    this.devs = response.data;
                });
        }
    }
}