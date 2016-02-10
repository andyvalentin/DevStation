namespace DevStation.Controllers {
    export class JobSearchController {
        public jobs;

        public searchJobs(searchTerm: string) {
            this.jobs = [];

            if (searchTerm) {
                this.$http.get(`/api/jobs/search/${searchTerm}`)
                    .then((response) => {
                        this.jobs = response.data;
                    });
            }
        }
        public constructor(private $http: ng.IHttpService) {

        }
    }
}