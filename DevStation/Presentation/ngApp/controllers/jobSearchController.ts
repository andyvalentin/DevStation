namespace DevStation.Controllers {
    export class JobSearchController {
        public jobs;

        public searchJobs(searchTerm: string) {
            this.jobs = [];

            if (searchTerm != "") {
                this.$http.get(`/api/jobs/search/${searchTerm}`)
                    .then((response) => {
                        this.jobs = response.data;
                    });
            }
            this.$http.get(`api/jobs/list`)
                .then((response) => {
                    this.jobs = response.data;
                });
        }

        public jobDetials(id: number) {
            this.$location.path(`/job/details/${id}`);
        }

        public constructor(private $http: ng.IHttpService, private $location) {
            this.$http.get(`api/jobs/list`)
                .then((response) => {
                    this.jobs = response.data;
                });
        }
    }
}