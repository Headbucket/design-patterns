from viewer import Viewer

class ViewerMean(Viewer):

    def get_output_string(self, value):
        return "Mean value: {}".format(value)