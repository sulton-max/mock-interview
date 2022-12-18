import Talents from "@/views/Dashboard/Talents.vue";
import Interviewers from "@/views/Dashboard/Interviewers.vue";
import Interviews from "@/views/Dashboard/Interviews.vue";

export const DashboardChildren = [
  {
    path: 'talents',
    name: 'Talents',
    component: Talents
  },
  {
    path: 'interviewers',
    name: 'Interviewers',
    component: Interviewers
  },
  {
    path: 'interviews',
    name: 'Interviews',
    component: Interviews
  }
]